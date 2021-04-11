using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Helpers.Ag_grid;
using MediatR;
using System.Collections.Generic;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries
{
    public class GetUsersListQuery : IRequest<BasicDataResponse<User>>
    {
        public int StartRow { get; }
        public int EndRow { get; }
        public SortModel[] SortModel { get; }
        public Dictionary<string, FilterModel> FilterModel { get; }

        public GetUsersListQuery(int startRow, int endRow, SortModel[] sortModel = null, Dictionary<string, FilterModel> filterModel = null)
        {
            StartRow = startRow;
            EndRow = endRow;
            SortModel = sortModel ?? System.Array.Empty<SortModel>();
            FilterModel = filterModel ?? new Dictionary<string, FilterModel>();
        }
    }
}
