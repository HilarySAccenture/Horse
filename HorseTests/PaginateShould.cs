using System.Collections.Generic;
using System.Linq;
using HorseKata;
using Xunit;
using Shouldly;

namespace HorseTests
{
    public class PaginateShould
    {
        [Fact]
        public void ReturnAllTableDataWhenNoPageSizeSpecified()
        {
            var tableData = new List<List<string>>
            {
                new List<string> {"apple", "cat", "green"},
                new List<string> {"grape", "cat", "pink"},
                new List<string> {"apple", "dog", "blue"}
            };
            PaginationMetadata paginationMetadata = null;
            
            Paginate.PaginateData(tableData, paginationMetadata).Count().ShouldBe(3);
        }

        [Fact]
        public void ReturnFirstFiveRowsInTableWhenPageSizeIsFiveAndFirstRecordInPageIsZero()
        {
            var tableData = new List<List<string>>
            {
                new List<string> {"kiwi", "cat", "green"},
                new List<string> {"grape", "cat", "pink"},
                new List<string> {"apple", "dog", "blue"},
                new List<string> {"banana", "dog", "blue"},
            };
            var paginationMetadata = new PaginationMetadata(0, 2);
            
            Paginate.PaginateData(tableData, paginationMetadata).Count().ShouldBe(2);
        }

        [Fact]
        public void ReturnTwoRowsStartingAtSpecifiedFirstRecordInPage()
        {
            var tableData = new List<List<string>>
            {
                new List<string> {"kiwi", "cat", "green"},
                new List<string> {"grape", "cat", "pink"},
                new List<string> {"apple", "dog", "blue"},
                new List<string> {"banana", "dog", "blue"},
            };
            var paginationMetadata = new PaginationMetadata(1, 2);
            
            Paginate.PaginateData(tableData, paginationMetadata).Count().ShouldBe(2);
            Paginate.PaginateData(tableData , paginationMetadata).First()[0].ShouldBe("grape");
            
        }

        [Fact]
        public void ReturnTwoRowsStartingAtSpecifiedFirstRecordInPageWhenFirstRecordMoreThanTwo()
        {
            var tableData = new List<List<string>>
            {
                new List<string> {"kiwi", "cat", "green"},
                new List<string> {"grape", "cat", "pink"},
                new List<string> {"apple", "dog", "blue"},
                new List<string> {"banana", "dog", "blue"},
                new List<string> {"cherry", "rat", "yellow"},
                new List<string> {"tomato", "dog", "blue"},
                new List<string> {"passion fruit", "dog", "blue"},
                new List<string> {"plum", "dog", "brown"},
                
            };
            var paginationMetadata = new PaginationMetadata(4, 2);
            
            Paginate.PaginateData(tableData, paginationMetadata).Count().ShouldBe(2);
            Paginate.PaginateData(tableData, paginationMetadata).First()[0].ShouldBe("cherry");
        }
        
        
    }

   
}