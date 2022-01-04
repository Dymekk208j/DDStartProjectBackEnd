using System.Collections.Generic;
using System.Data;

namespace AgGridApi.Models.Response
{
    public class ServerRowsResponse<T>
    {
        public IEnumerable<T> RowData { get; set; }
        public int RowCount { get; set; }

        public ServerRowsResponse() { }

        public ServerRowsResponse(IEnumerable<T> rowData, int rowCount)
        {
            RowData = rowData;
            RowCount = rowCount;
        }

    }
}
