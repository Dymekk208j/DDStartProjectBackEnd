namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid
{
    public class MyFilterConditional<T>
    {
        public MyFilter<T> Condition1 { get; set; }

        public MyFilter<T> Condition2 { get; set; }

        public Operator Operator { get; set; }
    }
}
