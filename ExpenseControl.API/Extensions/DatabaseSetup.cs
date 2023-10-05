using ExpenseControl.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.API.Extensions
{
    public static class DatabaseSetup
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ExpenseControlDB"));
            });
        }
    }
}
