using Transaction.Infrastructor.Entities;
using Microsoft.EntityFrameworkCore;

namespace Transaction.Infrastructor
{
    public class TempTransactionDbContext : DbContext
    {
        public TempTransactionDbContext(DbContextOptions<TempTransactionDbContext> options) : base(options)
        {
            
        }

        public DbSet<TM_Transaction> TM_TransactionData {  get; set; }

    }
}
