using AutoFixture;
using CsvHelper;
using CsvHelper.Configuration;
using EntityFrameworkCoreMock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.Xml.Linq;
using Transaction.Infrastructor;
using Transaction.Infrastructor.Entities;
using Transaction.Infrastructor.Repositories;
using Transaction.Infrastructor.Repositories.Interfaces;
using Xunit;

namespace TransactionData.Test
{
    public class TempTransactionRepositoryTest
    {
        private readonly ITempTransactionRepository _tempTransactionInitialData;
        private readonly IFixture fixture;

        public TempTransactionRepositoryTest()
        {
            var tempTransactionInitialData = new List<TM_Transaction> { };
            DbContextMock<TempTransactionDbContext> dbContextMock = new DbContextMock<TempTransactionDbContext>(new DbContextOptionsBuilder<TempTransactionDbContext>().Options);
            TempTransactionDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.TM_Transactions, tempTransactionInitialData);

            _tempTransactionInitialData = new TempTransactionRepository(dbContext);
            fixture = new Fixture();
        }

        [Fact]
        public async Task UploadTransactionFromCSVValid()
        {
            //Arrange
            var dataTable = CreateTestData();

            //Act
            var response = await _tempTransactionInitialData.UploadTransactionDataFormCSVAsync(dataTable);

            //Assert
            Assert.True(response);
            Assert.False(!response);
        }

        private DataTable CreateTestData()
        {
            var dataTable = new DataTable();
            var data = fixture.CreateMany<TD_Transaction>().ToList();
            var filePath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName + "\\FilesTemp";
            using (var writer = new StreamWriter(filePath + "\\test.csv"))
            using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWrite.WriteRecords(data);
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var streamReader = new StreamReader(filePath + "\\test.csv"))
            {
                using (var csvRead = new CsvReader(streamReader, config))
                {
                    csvRead.Read();
                    var dataReader = new CsvDataReader(csvRead);
                    dataTable.Load(dataReader);
                }
            }

            if (File.Exists(filePath + "\\test.csv"))
            {
                File.Delete(filePath + "\\test.csv");
            }

            return dataTable;
        }

    }
}