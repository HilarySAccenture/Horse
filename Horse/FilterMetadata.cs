namespace HorseKata
{
    public class FilterMetadata
    {

        public FilterMetadata(string columnHeader, string value) 
        {
            ColumnHeader = columnHeader;
            Value = value;
        }

        public string ColumnHeader { get; }
        public string Value { get; }
   
    }
}