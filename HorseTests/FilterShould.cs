using System.Collections.Generic;
using System.Linq;
using HorseKata;
using Xunit;
using Shouldly;

namespace HorseTests
{
    public class FilterShould
    {
        [Fact]
        public void ReturnAllTableDataWhenNoFiltersExist()
        {
            List<FilterMetadata> filters = null;
            var tableData =
                new List<List<string>>
                {
                    new List<string> {"string1", "string2"},
                    new List<string> {"string1", "string2"},
                    new List<string> {"stringA", "string3"},
                    new List<string> {"stringB", "string2"},
                    new List<string> {"stringC", "string3"}
                };
            var headers = new List<string> {"Fruit", "Animal"};
            
            Filter.FilterData(filters, tableData, headers).Count.ShouldBe(5);
        }

        [Fact]
        public void ReturnFilteredDataWhenOneFilterExists()
        {
            var headers = new List<string> {"Fruit", "Animal"};
            var tableData =
                new List<List<string>>
                {
                    new List<string> {"apple", "cat"},
                    new List<string> {"strawberry", "dog"},
                };

            var filters = new List<FilterMetadata>
            {
                new FilterMetadata("Fruit", "apple")
            };

            Filter.FilterData(filters, tableData, headers).Count.ShouldBe(1);
            Filter.FilterData(filters, tableData, headers).First()[0].ShouldBe("apple");
        }

        [Fact]
        public void ReturnFilteredDataWhenTwoFiltersExist()
        {
            var headers = new List<string> {"Fruit", "Animal", "Color"};
            var tableData = new List<List<string>>
            {
                new List<string> {"apple", "cat", "green"},
                new List<string> {"grape", "cat", "pink"},
                new List<string> {"apple", "dog", "blue"}
            };
            var filters = new List<FilterMetadata>
            {
                new FilterMetadata("Fruit", "apple"),
                new FilterMetadata("Color", "blue")
            };
            
             Filter.FilterData(filters, tableData, headers).Count.ShouldBe(1);
             Filter.FilterData(filters, tableData, headers).First()[0].ShouldBe("apple");
             Filter.FilterData(filters, tableData, headers).First()[2].ShouldBe("blue");
        }
        
  }
}