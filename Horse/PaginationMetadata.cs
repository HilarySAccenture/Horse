namespace HorseKata
{
    public class PaginationMetadata 
    {
        public PaginationMetadata(int firstRecordInPage, int pageSize) 
        {
            FirstRecordInPage = firstRecordInPage;
            PageSize = pageSize;
        }
  
        public int PageSize { get; }
        public int FirstRecordInPage { get; }
    }
}