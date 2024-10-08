namespace Transaction.Helpers
{
    public class ApiHelper
    {
        //public readonly static string API_URL = "http://host.docker.internal:8082";

        public readonly static string API_URL = "http://localhost:5262";


        public readonly static string TransactionApi = API_URL + "/api/transactionApi";
        public readonly static string UploadTransactionDataFromCSVApi = TransactionApi + "/upload-transaction-csv";
        public readonly static string UploadTransactionDataFromXMLApi = TransactionApi + "/upload-transaction-xml";


        public readonly static string SearchTransactionDataApi = TransactionApi + "/transaction-data";
        public readonly static string GetAllCurrencyCodeApi = TransactionApi + "/currencyCode-all";
        public readonly static string GetAllStatusApi = TransactionApi + "/status-all";
    }
}
