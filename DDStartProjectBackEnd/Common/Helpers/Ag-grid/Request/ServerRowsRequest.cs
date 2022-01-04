using DDStartProjectBackEnd.Common.Helpers.Ag_grid.Filter;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid.Request
{
    public class ServerRowsRequest
    {
        // start from 0
        [JsonProperty("pageIndex", NullValueHandling = NullValueHandling.Ignore)]
        public int PageIndex { set; get; }
        [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int PageSize { set; get; }

        public int StartRow { set; get; } = 0;

        public int EndRow { set; get; } = 20;

        // row group columns
        public List<ColumnVO> RowGroupCols { set; get; }

        // value columns
        public List<ColumnVO> ValueCols { set; get; }

        // pivot columns
        public List<ColumnVO> PivotCols { set; get; }

        // true if pivot mode is one, otherwise false
        public bool IsPivotMode { set; get; }

        // what groups the user is viewing
        public List<string> GroupKeys { set; get; }


        [JsonProperty("filterModel")]
        // if filtering, what the filter model is
        public List<ColumnFilter> FilterModel { get; set; }

        [JsonProperty("sortModel")]
        // if sorting, what the sort model is
        public List<SortModel> SortModel { set; get; }

        public ServerRowsRequest()
        {
            RowGroupCols = new List<ColumnVO>();
            ValueCols = new List<ColumnVO>();
            PivotCols = new List<ColumnVO>();
            GroupKeys = new List<string>();
            FilterModel = new List<ColumnFilter>();
            SortModel = new List<SortModel>();
        }

        public string GetFilters()
        {
            if (FilterModel.Count <= 0)
                return string.Empty;

            StringBuilder filters = new StringBuilder(" 1=1 ");
            foreach (ColumnFilter filterModel in FilterModel)
            {
                filters.Append(" AND (");
                for (int i = 0; i < filterModel.Condition.Count; i++)
                {
                    filters.Append(filterModel.Condition[i].GetFilterCondition(filterModel.Head.Field));
                    if (i + 1 < filterModel.Condition.Count)
                        filters.Append(Constants.WHITESPACE + filterModel.Head.Operate.ToStringEx() + Constants.WHITESPACE);
                }

                filters.Append(") ");
            }

            return filters.ToStringEx();
        }

        public string GetSorts()
        {
            if (SortModel.Count <= 0)
                return string.Empty;

            StringBuilder sorts = new(Constants.WHITESPACE);
            foreach (SortModel sort in SortModel)
            {
                sorts.Append(Constants.WHITESPACE + "[" + sort.ColId + "]" + Constants.WHITESPACE).
                    Append(sort.Sort.ToUpper() + Constants.COMMA);
            }

            return sorts.ToStringEx().TrimLastCharacter();
        }

        //public string GetGroups()
        //{
        //    if (RowGroupCols.Count == 0 ||
        //        GroupKeys.Count > 0)
        //        return string.Empty;

        //    return string.Join(",", RowGroupCols
        //        .Select(s => s.Id));
        //}

        //public string GetGroupWheres()
        //{
        //    if (RowGroupCols.Count == 0 ||
        //        GroupKeys.Count == 0)
        //        return string.Empty;
        //    string where = string.Empty;
        //    for (int i = 0; i < GroupKeys.Count; i++)
        //    {
        //        where += " and " + RowGroupCols[i].Id +
        //            " = '" + GroupKeys[i] + "'";
        //    }

        //    return where.ToStringEx();
        //}

    }
}
