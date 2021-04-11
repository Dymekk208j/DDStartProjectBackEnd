using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid
{
    public class ServerSideGetRowsRequest
    {
        [JsonPropertyName("startRow")]
        public int StartRow { get; set; }

        [JsonPropertyName("endRow")]
        public int EndRow { get; set; }

        [JsonPropertyName("SortModel")]
        public SortModel[] SortModel { get; set; }

        [JsonPropertyName("FilterModel")]
        public Dictionary<string, FilterModel> FilterModel { get; set; }

    }
}
