using System;
using System.Collections.Generic;

namespace DDStartProjectBackEnd.Common.Helpers.Ag_grid
{
    public class AgGridTableRequest<TColumnsNamesEnum>
    {
        public int StartRow { get; private set; }

        public int EndRow { get; private set; }

        public SortModel[] SortModel { get; set; }

        public Dictionary<string, MyFilter<string>> TextFilters { get; private set; }
        public Dictionary<string, MyFilterConditional<string>> TextConditionalFilters { get; private set; }

        public Dictionary<string, MyFilter<int>> NumberFilters { get; private set; }
        public Dictionary<string, MyFilterConditional<int>> NumberConditionalFilters { get; private set; }

        public Dictionary<string, MyFilter<DateTime>> DateTimeFilters { get; private set; }
        public Dictionary<string, MyFilterConditional<DateTime>> DateTimeConditionalFilters { get; private set; }

        public AgGridTableRequest(ServerSideGetRowsRequest serverSideGetRowsRequest)
        {
            if (serverSideGetRowsRequest == null)
                throw new ArgumentNullException(nameof(serverSideGetRowsRequest));
            FillFiltersProperties(serverSideGetRowsRequest);
            StartRow = serverSideGetRowsRequest.StartRow;
            EndRow = serverSideGetRowsRequest.EndRow;
            SortModel = serverSideGetRowsRequest.SortModel;

        }

        void FillFiltersProperties(ServerSideGetRowsRequest _serverSideGetRowsRequest)
        {
            foreach (var filter in _serverSideGetRowsRequest.FilterModel)
            {
                if (filter.Value.Condition1 != null && filter.Value.Condition2 != null)
                {
                    switch (filter.Value.Condition1.FilterType)
                    {
                        case "text":
                            var obj = new MyFilterConditional<string>
                            {
                                Operator = Enum.Parse<Operator>(filter.Value.LogicOperator),
                                Condition1 = new MyFilter<string>(filter.Value.Condition1.Filter, filter.Value.Condition1.Type),
                                Condition2 = new MyFilter<string>(filter.Value.Condition2.Filter, filter.Value.Condition2.Type)
                            };

                            TextConditionalFilters.Add(filter.Key, obj);
                            break;
                        case "number":
                            var objN = new MyFilterConditional<int>
                            {
                                Operator = Enum.Parse<Operator>(filter.Value.LogicOperator),
                                Condition1 = new MyFilter<int>(int.Parse(filter.Value.Condition1.Filter), filter.Value.Condition1.Type),
                                Condition2 = new MyFilter<int>(int.Parse(filter.Value.Condition2.Filter), filter.Value.Condition2.Type)
                            };

                            NumberConditionalFilters.Add(filter.Key, objN);
                            break;
                        case "date":
                            var objD = new MyFilterConditional<DateTime>
                            {
                                Operator = Enum.Parse<Operator>(filter.Value.LogicOperator),
                                Condition1 = new MyFilter<DateTime>(DateTime.Parse(filter.Value.Condition1.Filter), filter.Value.Condition1.Type),
                                Condition2 = new MyFilter<DateTime>(DateTime.Parse(filter.Value.Condition2.Filter), filter.Value.Condition2.Type)
                            };

                            DateTimeConditionalFilters.Add(filter.Key, objD);
                            break;
                        case "set"://todo
                            break;
                    }
                }
                else
                {
                    if (filter.Key == "text")
                    {
                        TextFilters.Add(filter.Key, new MyFilter<string>(filter.Value.Filter, filter.Value.Type));
                    }
                    if (filter.Key == "number")
                    {
                        NumberFilters.Add(filter.Key, new MyFilter<int>(int.Parse(filter.Value.Filter), filter.Value.Type));
                    }
                    if (filter.Key == "date")
                    {
                        DateTimeFilters.Add(filter.Key, new MyFilter<DateTime>(DateTime.Parse(filter.Value.Filter), filter.Value.Type));
                    }
                    if (filter.Key == "set")//todo
                    {
                    }
                }
            }

        }

    }
}
