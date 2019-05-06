namespace HorseKata
{
    public class SortMetadata
    {
        public SortMetadata(string columnHeader, string sortOrder)
        {
            ColumnHeader = columnHeader;
            SortOrder = sortOrder;
        }

        public string SortOrder { get; }
        public string ColumnHeader { get; }
    }
}