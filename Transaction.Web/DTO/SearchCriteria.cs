namespace Transaction.Web.DTO
{
    public class SearchCriteria
    {
        public string CurrencyCode { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Status { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public int TotalRecords { get; set; } 
    }
   
}
