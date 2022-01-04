namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid.Request
{
    public class ColumnVO
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Field { get; set; }
        public string AggFunc { get; set; }

        public ColumnVO()
        {
        }

        public ColumnVO(string id, string displayName, string field, string aggFunc)
        {
            Id = id;
            DisplayName = displayName;
            Field = field;
            AggFunc = aggFunc;
        }
    }
}
