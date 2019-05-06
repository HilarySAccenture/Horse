using Xunit;
using System.Collections.Generic;
using System.Linq;
using HorseKata;
using Shouldly;

namespace HorseTests
{
    public class SortShould
    {
        [Fact]
        public void ReturnAllDataWhenNoSortColumnSpecified()
        {
            var tableData = new List<List<string>>
            {
                new List<string> {"apple", "cat", "green"},
                new List<string> {"grape", "cat", "pink"},
                new List<string> {"apple", "dog", "blue"}
            };
            SortMetadata sortMetadata = null;
            var headers = new List<string> {"Fruit", "Animal"};

            Sort.SortData(tableData, sortMetadata, headers).Count.ShouldBe(3);
        }

        [Fact]
        public void ReturnTableDataInABCAscendingOrderWhenSortOrderIsAscending()
        {
            var tableData = new List<List<string>>
            {
                new List<string> {"apple", "cat", "green"},
                new List<string> {"grape", "cat", "pink"},
                new List<string> {"apple", "dog", "blue"}
            };
            var sortMetadata = new SortMetadata("Fruit", "Ascending");
            var headers = new List<string> {"Fruit", "Animal"};

            Sort.SortData(tableData, sortMetadata, headers).First()[0].ShouldBe("apple");
            Sort.SortData(tableData, sortMetadata, headers)[1][0].ShouldBe("apple");
            Sort.SortData(tableData, sortMetadata, headers)[2][0].ShouldBe("grape");
        }
 
        [Fact]
        public void ReturnTableDataInABCDescendingOrderWhenSortOrderIsDescending()
        {
            var tableData = new List<List<string>>
            {
                new List<string> {"apple", "cat", "green"},
                new List<string> {"grape", "cat", "pink"},
                new List<string> {"apple", "dog", "blue"}
            };
            var sortMetaData = new SortMetadata("Color", "Descending");
            var headers = new List<string> {"Fruit", "Animal", "Color"};

            Sort.SortData(tableData, sortMetaData, headers).First()[2].ShouldBe("pink");
            Sort.SortData(tableData, sortMetaData, headers)[1][2].ShouldBe("green");
            Sort.SortData(tableData, sortMetaData, headers)[2][2].ShouldBe("blue");

        }

        [Fact]
        public void ReturnTableDataInNumericAscendingOrderWhenSortOrderIsDescending()
        {
            var tableData = new List<List<string>>
            {
                new List<string> {"apple", "cat", "5"},
                new List<string> {"grape", "cat", "1"},
                new List<string> {"apple", "dog", "3"}
            };
            var sortMetaData = new SortMetadata("Number", "Ascending");
            var headers = new List<string> {"Fruit", "Animal", "Number"};

            Sort.SortData(tableData, sortMetaData, headers).First()[2].ShouldBe("1");
            Sort.SortData(tableData, sortMetaData, headers)[1][2].ShouldBe("3");
            Sort.SortData(tableData, sortMetaData, headers)[2][2].ShouldBe("5");
        }

     
    }
}