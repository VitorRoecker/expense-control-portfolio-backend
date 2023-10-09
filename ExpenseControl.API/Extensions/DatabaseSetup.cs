using ExpenseControl.Infra.Context;
using ExpenseControl.Infra.External_Dependence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExpenseControl.API.Extensions
{
    public static class DatabaseSetup
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetValue<string>("AppSettings:ConnectionStrings:ExpenseControlDB")!);
            });
        }
    }
}
