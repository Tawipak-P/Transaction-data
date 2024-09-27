﻿using Transaction.Infrastructor.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Transaction.Infrastructor.StoreProcedures;

namespace Transaction.Infrastructor.Repositories
{
    public class TempTransactionRepository : ITempTransactionRepository
    {
        private readonly TempTransactionDbContext _tempDbContext;
        private readonly ILogger<TempTransactionRepository> _logger;

        #region Constructor
        public TempTransactionRepository(TempTransactionDbContext tempDbContext, ILogger<TempTransactionRepository> logger)
        {
            _tempDbContext = tempDbContext;
            _logger = logger;
        }
        #endregion

        public async Task<bool> UploadTransactionDataFormCSVAsync(DataTable dataTable)
        {
            try
            {
                var sqlParam = new SqlParameter("@DataTable", dataTable)
                {
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "dbo.TransactionTableType"
                };
                var result = await _tempDbContext.Set<InsertTransactionDataResults>().FromSqlRaw("EXECUTE dbo.SP_InsertTransactionDataFromCSV @DataTable", sqlParam).ToListAsync();

                if (result.FirstOrDefault().TotalRecords > 0)
                {
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return false;
            }
        }

        public async Task<bool> UploadTransactionDataFromXMLAsync(XDocument xDocument)
        {
            try
            {
                var sqlParam = new SqlParameter("@XmlInput", xDocument.ToString())
                {
                    SqlDbType = SqlDbType.Xml,
                };
                var result = await _tempDbContext.Set<InsertTransactionDataResults>().FromSqlRaw("EXECUTE dbo.SP_InsertTransactionDataFromXML @XmlInput", sqlParam).ToListAsync();

                if (result.FirstOrDefault().TotalRecords > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return false;
            }
        }
    }
}
