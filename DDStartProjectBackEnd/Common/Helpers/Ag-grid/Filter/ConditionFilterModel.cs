using System;
using System.Collections.Generic;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid.Filter
{
    public class ConditionFilterModel
    {
        public string Type { get; set; }


        public string FilterType { get; set; }

        public string Filter { get; set; }

        public string FilterTo { get; set; }

        public string DateFrom { get; set; }

        public string DateTo { get; set; }

        public List<string> Values { get; set; }

        public ConditionFilterModel()
        {
            Type = string.Empty;
            Filter = string.Empty;
            FilterTo = string.Empty;
            FilterType = string.Empty;
            DateFrom = string.Empty;
            DateTo = string.Empty;
            Values = new List<string>();
        }
    }
}