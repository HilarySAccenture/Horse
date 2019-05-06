using System.Collections.Generic;
using System.Linq;

namespace HorseKata
{
    public static class Sort
    {
        private static List<List<string>> _tableData;
        private static SortMetadata _sortMetadata;
        private static List<string> _headers;

        public static List<List<string>> SortData(List<List<string>> tableData, SortMetadata sortMetadata, List<string> headers)
        {
            _tableData = tableData;
            _sortMetadata = sortMetadata;
            _headers = headers;
            
            if (_sortMetadata == null) return _tableData;
            List<List<string>> sortedData = new List<List<string>>();
            
            int headerIndex = _headers.IndexOf(_sortMetadata.ColumnHeader);

            if (_sortMetadata.SortOrder == "Ascending")
            {
                sortedData = _tableData.OrderBy(row => row[headerIndex]).ToList();
            }
            else
            {
                sortedData = _tableData.OrderByDescending(row => row[headerIndex]).ToList();
            }

            return sortedData;
        }
    }
}