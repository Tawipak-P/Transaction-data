namespace Transaction.Helpers
{
    public class ApiHelper
    {
        //public readonly static string API_URL = "http://host.docker.internal:8082";

        public readonly static string API_URL = "http://localhost:7002";


        public readonly static string TransactionApi = API_URL + "/api/transactionApi";
        public readonly static string UploadTransactionWithSqlBlukCopyApi = TransactionApi + "/upload-transaction";


        public readonly static string SearchTransactionDataApi = TransactionApi + "/transaction-data";
        public readonly static string GetAllCurrencyCodeApi = TransactionApi + "/currencyCode-all";
        public readonly static string GetAllStatusApi = TransactionApi + "/status-all";
    }
}
