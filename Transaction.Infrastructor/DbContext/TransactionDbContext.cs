using Transaction.Infrastructor.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2C2P.AssignmentTest.Infrastructor.Entities;

namespace Transaction.Infrastructor
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
            
        }

        public DbSet<TD_Transaction> TD_Transactions {  get; set; }
        public DbSet<TD_Status> TD_Statuses { get; set; }

        
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

            base.OnModelCreating(modelBuilder);
        }


    }
}
