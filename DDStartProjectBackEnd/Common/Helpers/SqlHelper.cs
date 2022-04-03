using DDStartProjectBackEnd.Common.Helpers.Ag_grid.Request;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DDStartProjectBackEnd.Common.Helpers
{
    public class SqlHelper<T>
    {
        /// <summary>
        /// Get sql script from embbeded file. Sql file has to be nested in Sql folder on class branch level. ./Sql/{ClassName}/
        /// </summary>
        /// <param name="sqlName">Sql filename</param>
        /// <param name="nestedInClassNameFolder">If true adding ClassName to the path. ./Sql/{ClassName}/{SqlName}.Sql</param>
        /// <returns>Sql script</returns>
        public string GetSql(string sqlName, bool nestedInClassNameFolder = true)
        {
            string result;

            if (!sqlName.ToLower().EndsWith(".sql"))
                sqlName += ".sql";

            string path =
                 typeof(T).FullName.Substring(0, typeof(T).FullName.Length - typeof(T).Name.Length) + "sql.";

            if (nestedInClassNameFolder) path += typeof(T).Name + ".";

            var assembly = Assembly.GetExecutingAssembly();
            string[] names = assembly.GetManifestResourceNames();
            if (names.Any(name =>
            name.ToUpper().StartsWith(path.ToUpper())
             && name.ToUpper().EndsWith(sqlName.ToUpper())
             && !name.ToUpper().EndsWith(nestedInClassNameFolder ? ".SQL." + typeof(T).Name.ToUpper() + "." + sqlName.ToUpper() : ".SQL." + sqlName.ToUpper())
             ))
                throw new DirectoryNotFoundException("Sql file is not in Sql/ClassName folder, or folder is not in main root of class");

            path += sqlName;

            var resName = names.FirstOrDefault(name => name.ToUpper() == path.ToUpper());

            if (string.IsNullOrEmpty(resName)) throw new FileNotFoundException($"Sql file ({path.ToUpper()}) not found or it is not embedded resource");

            using (Stream stream = assembly.GetManifestResourceStream(resName))
            {
                if (stream == null) throw new FileNotFoundException("Sql file not exist or it is not embedded resource");
                using StreamReader reader = new(stream);
                result = reader.ReadToEnd();
            }

            return result;
        }

        /// <summary>
        /// Get sql script from embbeded file. Sql file has to be nested in Sql folder on class branch level. ./Sql/{customPath}/
        /// </summary>
        /// <param name="sqlName">Sql filename</param>
        /// <param name="customPath">Custom path which start in ./sql. Use dot(.) insted of slash (/) (e.g  <b>user.test</b> for <b>user/test</b>)</param>
        /// <param name="nestedInClassNameFolder">If true adding ClassName to the path. ./Sql/{ClassName}/{SqlName}.Sql</param>
        /// <returns>Sql script</returns>
        public string GetSql(string sqlName, string customPath, bool nestedInClassNameFolder = false)
        {
            return GetSql(sqlName, nestedInClassNameFolder);
        }

        public string GetSql(bool nestedInClassNameFolder = true, [CallerMemberName] string callerName = "")
        {
            return GetSql(callerName, nestedInClassNameFolder);
        }

        public string GetAgGridSelectSql(ServerRowsRequest request, bool nestedInClassNameFolder = true, [CallerMemberName] string callerName = "")
        {
            var filters = request.GetFilters();
            var sorts = request.GetSorts();

            var sql = GetSql(nestedInClassNameFolder, callerName);

            if (string.IsNullOrEmpty(sql))
                throw new FileNotFoundException("Sql file not exist or it is not embedded resource");

            var result = $"SELECT * FROM ({sql}) as MainSQL ";

            if (!string.IsNullOrEmpty(filters))
            {
                result = $"{result} WHERE {filters}";
            }
            result += $" ORDER BY ";

            result += string.IsNullOrEmpty(sorts) ? " 1 " : $" {sorts} ";

            result += $"OFFSET @startRow ROWS FETCH NEXT @endRow-@startRow ROWS ONLY";

            return result;
        }

        public string GetAgGridTotalRowsCountFromSelectQuerySql(string sqlName, string identityColumnName, ServerRowsRequest request)
        {
            var filters = request.GetFilters();

            var sql = GetSql(sqlName);

            if (string.IsNullOrEmpty(sql))
                throw new FileNotFoundException("Sql file not exist or it is not embedded resource");

            var result = $"SELECT COUNT(mainSql.[{identityColumnName}]) FROM ({sql}) as MainSQL ";

            if (!string.IsNullOrEmpty(filters))
            {
                result = $"{result} WHERE {filters}";
            }

            return result;
        }

        public string GetAgGridTotalRowsCountWithoutJoinsSql(string tableName, string identityColumnName, ServerRowsRequest request)
        {
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(identityColumnName))
                throw new InvalidFilterCriteriaException("Table name and identity column name are mandatory");

            var filters = request.GetFilters();
            var sql = $@"SELECT
                         COUNT([{identityColumnName}]) as Total
                        FROM
                          [{tableName}]";

            if (filters.Any())
                sql += $" WHERE {filters}";

            return sql;
        }

    }
}
