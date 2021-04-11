using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid
{
    public class BasicDataRequest
    {
        [JsonPropertyName("startRow")]
        public int StartRow { get; set; }

        [JsonPropertyName("endRow")]
        public int EndRow { get; set; }

        [JsonPropertyName("sortModel")]
        public SortModel[] SortModel { get; set; }

        [JsonPropertyName("filterModel")]
        public Dictionary<string, FilterModel> FilterModel { get; set; }

    }
}
