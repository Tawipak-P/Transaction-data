

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Transaction.Infrastructor;

namespace Transaction.Api.Extensions
{
    public class DatabaseMigrationExtensions : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseMigrationExtensions(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var dbContext = service.GetRequiredService<TransactionDbContext>();

                try
                {
                    await dbContext.Database.MigrateAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
