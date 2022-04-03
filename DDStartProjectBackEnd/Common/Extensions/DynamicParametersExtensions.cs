using Dapper;
using System;

namespace DDStartProjectBackEnd.Common.Extensions
{
    public static class DynamicParametersExtensions
    {
        public static DynamicParameters AddCreationBaseData(this DynamicParameters dynamicParameters, string createdByUserId)
        {
            dynamicParameters.Add("CreationDate", DateTime.UtcNow);
            dynamicParameters.Add("CreatedByUserId", createdByUserId);
            dynamicParameters.Add("IsDeleted", 0);

            return dynamicParameters;
        }

        public static DynamicParameters AddModificationBaseData(this DynamicParameters dynamicParameters, string modifiedByUserId)
        {
            dynamicParameters.Add("LastModificationDate", DateTime.UtcNow);
            dynamicParameters.Add("ModifiedByUserId", modifiedByUserId);

            return dynamicParameters;
        }
    }
}
