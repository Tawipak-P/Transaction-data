using Transaction.Infrastructor.StoreProcedures;
using Microsoft.EntityFrameworkCore;
using Transaction.Infrastructor.Entities;

namespace Transaction.Infrastructor
{
    public class TempTransactionDbContext : DbContext
    {
        public TempTransactionDbContext(DbContextOptions<TempTransactionDbContext> options) : base(options)
        {
            
        }

        public DbSet<TM_Transaction> TM_Transactions {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsertTransactionDataResults>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

    }
}
