using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Infra.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Infra.Context
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> builder) : IdentityDbContext<User>(builder)
    {
        public DbSet<Expense> Expense {  get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Mappings

            builder.ApplyConfiguration(new ExpenseMap());
            builder.ApplyConfiguration(new IncomeMap());
            builder.ApplyConfiguration(new CategoryMap());

            #endregion
        }
    }
}
