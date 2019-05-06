using System;
using System.Collections.Generic;
using HorseKata;
using Xunit;
using Shouldly;

namespace HorseTests
{
    public class HorseTests
    {
        [Fact]
        public void FilterSortPaginateFilters()
        {
            List<String> headers = SampleHorseData.GetSampleHeaders();
            List<List<string>> tableData = SampleHorseData.GetSampleTableData();
            List<FilterMetadata> filters = new List<FilterMetadata> 
            {
                new FilterMetadata("Colour", "Bay")
              };
            SortMetadata sortMetadata = null;
            PaginationMetadata paginationMetadata = null;
            var expectedTableData = new List<List<string>>
            {
                new List<string> {"Thoroughbred", "Bay", "1.66", "3", "true"},
                new List<string> {"Arabian horse", "Bay", "1.51", "5", "true"}
            };

            PaginatedTable table =
                Horse.FilterSortPaginateTable(headers, tableData, filters, sortMetadata, paginationMetadata);

            table.Headers.ShouldBe(headers);
            table.TotalRows.ShouldBe(2);
            table.TableData.ShouldBe(expectedTableData);
        }
        
        [Fact]
        public void FilterSortPaginateFiltersAndSorts()
        {
            List<String> headers = SampleHorseData.GetSampleHeaders();
            List<List<string>> tableData = new List<List<string>>
            {
                new List<string> {"Thoroughbred", "Grey", "1.55", "3", "true"},
                new List<string> {"Arabian horse", "Bay", "1.51", "5", "true"},
                new List<string> {"Shetland Pony", "Bay", "1.01", "2", "false"},
                new List<string> {"Shire horse", "Black", "1.71", "4", "true"},
                new List<string> {"Thoroughbred", "Bay", "1.66", "3", "true"},
            };
            List<FilterMetadata> filters =  new List<FilterMetadata> 
            {
                new FilterMetadata("Colour", "Bay")
                
            };
            SortMetadata sortMetadata = new SortMetadata("Height", "Ascending");
            PaginationMetadata paginationMetadata = null;
            var expectedTableData = new List<List<string>>
            {
                new List<string> {"Shetland Pony", "Bay", "1.01", "2", "false"},
                new List<string> {"Arabian horse", "Bay", "1.51", "5", "true"},
                new List<string> {"Thoroughbred", "Bay", "1.66", "3", "true"},
            };

            PaginatedTable table =
                Horse.FilterSortPaginateTable(headers, tableData, filters, sortMetadata, paginationMetadata);

            table.Headers.ShouldBe(headers);
            table.TotalRows.ShouldBe(3);
            table.TableData.ShouldBe(expectedTableData);
        }
        
        [Fact]
        public void FilterSortPaginateFiltersSortsAndPaginates()
        {
            List<String> headers = SampleHorseData.GetSampleHeaders();
            List<List<string>> tableData = new List<List<string>>
            {
                new List<string> {"Thoroughbred", "Grey", "1.55", "3", "true"},
                new List<string> {"Arabian horse", "Bay", "1.51", "5", "true"},
                new List<string> {"Shetland Pony", "Bay", "1.01", "2", "false"},
                new List<string> {"Shire horse", "Black", "1.71", "4", "true"},
                new List<string> {"Thoroughbred", "Bay", "1.66", "3", "true"},
                new List<string> {"Thoroughbred", "Bay", "1.89", "4", "false"}
            };
            List<FilterMetadata> filters = new List<FilterMetadata>
            {
                new FilterMetadata("Colour", "Bay")
            };
            SortMetadata sortMetadata = new SortMetadata("Height", "Ascending");
            PaginationMetadata paginationMetadata = new PaginationMetadata(1, 3);
            var expectedTableData = new List<List<string>>
            {
                new List<string> {"Arabian horse", "Bay", "1.51", "5", "true"},
                new List<string> {"Thoroughbred", "Bay", "1.66", "3", "true"},
                new List<string> {"Thoroughbred", "Bay", "1.89", "4", "false"}
            };

            PaginatedTable table =
                Horse.FilterSortPaginateTable(headers, tableData, filters, sortMetadata, paginationMetadata);

            table.Headers.ShouldBe(headers);
            table.TotalRows.ShouldBe(3);
            table.TableData.ShouldBe(expectedTableData);
        }
        
    }
}
