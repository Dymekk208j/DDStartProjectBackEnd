using System.Text.Json.Serialization;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid
{
    public class SortModel
    {
        [JsonPropertyName("colId")]
        public string ColumnId { get; set; }

        [JsonPropertyName("sort")]
        public string Direction { get; set; }
    }
}
