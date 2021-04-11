using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid
{
    public class BasicDataResponse<T>
    {
        [JsonPropertyName("rowData")]
        public IEnumerable<T> RowData{ get; set; }
        
        [JsonPropertyName("rowCount")]
        public int TotalRows{ get; set; }
    }
}
