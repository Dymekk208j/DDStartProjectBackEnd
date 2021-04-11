using System;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid
{
    public class MyFilter<T>
    {
        public MyFilter()
        {

        }

        public MyFilter(T value, FilterType filterType)
        {
            Filter = value;
            FilterTyp = filterType;
        }

        public MyFilter(T value, string filterType)
        {
            Filter = value;
            FilterTyp = Enum.Parse<FilterType>(filterType, true);
        }

        public T Filter { get; set; }
        public FilterType FilterTyp { get; set; }
    }
}
