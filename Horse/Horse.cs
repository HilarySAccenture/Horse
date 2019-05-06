using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HorseKata
{
    public class Horse
    {
        // This method is called by the front end when it wants to display a page of horse data.
        
        public static PaginatedTable FilterSortPaginateTable(
            List<string> headers,
            List<List<string>> tableData,
            List<FilterMetadata> filters,
            SortMetadata sortMetadata,
            PaginationMetadata paginationMetadata)
        {
            var filterData = Filter.FilterData(filters, tableData, headers);
            var sortedandFiltered = Sort.SortData(filterData, sortMetadata, headers);
            var paginatedSortedAndFiltered = Paginate.PaginateData(sortedandFiltered, paginationMetadata);

            return new PaginatedTable(headers, paginatedSortedAndFiltered, paginatedSortedAndFiltered.Count);
        }
    }
}