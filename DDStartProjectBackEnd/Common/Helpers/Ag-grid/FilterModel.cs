using System;
using System.Text.Json.Serialization;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid
{
    public class FilterModel
    {
        [JsonPropertyName("condition1")]
        public FilterModel Condition1 { get; set; }

        [JsonPropertyName("condition2")]
        public FilterModel Condition2 { get; set; }

        [JsonPropertyName("operator")]
        public string LogicOperator { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        [JsonPropertyName("filterTo")]
        public string FilterTo { get; set; }

        [JsonPropertyName("dateFrom")]
        public DateTime? DateFrom { get; set; }

        [JsonPropertyName("dateTo")]
        public DateTime? DateTo { get; set; }

        [JsonPropertyName("filterType")]
        public string FilterType { get; set; }

    }
}
