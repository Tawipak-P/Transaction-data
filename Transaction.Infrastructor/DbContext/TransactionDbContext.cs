using Transaction.Infrastructor.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Infrastructor.StoreProcedures;

namespace Transaction.Infrastructor
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<TD_Transaction> TD_Transactions {  get; set; }
        public DbSet<TD_Status> TD_Statuses { get; set; }
        public DbSet<TD_CurrencyCode> TD_CurrencyCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionDataResults>().HasNoKey();

            modelBuilder.Entity<TD_Status>().HasData(new List<TD_Status>
            {
                new TD_Status() { Id = 1, Name = "Approved", Prefix = "A" },
                new TD_Status() { Id = 2, Name = "Rejected", Prefix = "R" },
                new TD_Status() { Id = 3, Name = "Done", Prefix = "D" },
                new TD_Status() { Id = 4, Name = "Failed", Prefix = "R" },
                new TD_Status() { Id = 5, Name = "Finished", Prefix = "D" }
            });



            modelBuilder.Entity<TD_CurrencyCode>().HasData(new List<TD_CurrencyCode>
            {
                new TD_CurrencyCode() { Id = 1, CurrencyCode = "USD" },
                new TD_CurrencyCode() { Id = 2, CurrencyCode = "EUR" },
                new TD_CurrencyCode() { Id = 3, CurrencyCode = "JPY" },
                new TD_CurrencyCode() { Id = 4, CurrencyCode = "GBP" },
                new TD_CurrencyCode() { Id = 5, CurrencyCode = "AUD" },
                new TD_CurrencyCode() { Id = 6, CurrencyCode = "CAD" },
                new TD_CurrencyCode() { Id = 7, CurrencyCode = "CHF" },
                new TD_CurrencyCode() { Id = 8, CurrencyCode = "CNY" },
                new TD_CurrencyCode() { Id = 9, CurrencyCode = "SEK" },
                new TD_CurrencyCode() { Id = 10, CurrencyCode = "NZD" }
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
