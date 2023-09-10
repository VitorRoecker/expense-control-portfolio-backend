using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExpenseControl.Infra.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionString = _configuration.GetConnectionString("ExpenseControlDB");
            builder.UseSqlServer(connectionString);
        }
    }
}
