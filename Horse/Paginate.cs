using System.Collections.Generic;

namespace HorseKata
{
    public static class Paginate
    {
        private static List<List<string>> _tableData;
        private static PaginationMetadata _paginationMetadata;
        public static List<List<string>> PaginateData(List<List<string>> tableData, PaginationMetadata paginationMetadata)
        {
            _tableData = tableData;
            _paginationMetadata = paginationMetadata;
            
            if (_paginationMetadata == null) return _tableData;

            var paginateData = new List<List<string>>();
            var pageSize = _paginationMetadata.PageSize + _paginationMetadata.FirstRecordInPage;

            for (var i = _paginationMetadata.FirstRecordInPage; i < pageSize; i++)
            {
                paginateData.Add(_tableData[i]);
            }
            return paginateData;
        }
    
    }
}