using System.Collections.Generic;
using System.Linq;

namespace HorseKata
{
    public static class Filter
    {
        private static  List<FilterMetadata> _filters;
        private static  List<List<string>> _tableData;
        private static  List<string> _headers;
   
        public static List<List<string>> FilterData(List<FilterMetadata> filters, List<List<string>> tableData, List<string> headers)
        {
            _filters = filters;
            _tableData = tableData;
            _headers = headers;
            
            var filterData = new List<List<string>>();

            if (_filters == null) return _tableData;

            foreach (var row in _tableData)
            {
                var matchesAllFilters = true;

                foreach (var filter in _filters)
                {
                    var headerIndex = _headers.IndexOf(filter.ColumnHeader);

                    if (row[headerIndex] == filter.Value && matchesAllFilters)
                    {
                    }
                    else
                    {
                        matchesAllFilters = false;
                    }
                }

                if (matchesAllFilters)
                    filterData.Add(row);
            }

            return filterData;
        }
    }
}