namespace Transaction.Api.DTO
{
    public class SearchCriteria
    {
        public string CurrencyCode { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Status { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public int TotalRecords { get; set; } 

        public DateTime ConvertToDateFrom()
        {
            return Convert.ToDateTime( DateFrom != null ? Convert.ToDateTime(DateFrom).ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.AddMonths(-1));
        }
        public DateTime ConvertToDateTo()
        {
            return Convert.ToDateTime(
                DateTo != null ? Convert.ToDateTime(DateTo).ToString("yyyy-MM-dd") + " 11:59:59 PM": DateTime.Now.ToString("yyyy-MM-dd") + " 11:59:59 PM"
            );
        }

    }
   
}
