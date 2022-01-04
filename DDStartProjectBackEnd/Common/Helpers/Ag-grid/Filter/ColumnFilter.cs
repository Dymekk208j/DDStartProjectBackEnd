using System.Collections.Generic;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid.Filter
{
    public class ColumnFilter
    {
        public HeadFilterModel Head { get; set; }

        public List<ConditionFilterModel> Condition { get; set; }

        public ColumnFilter()
        {
            Head = new HeadFilterModel();
            Condition = new List<ConditionFilterModel>();
        }
    }
}
