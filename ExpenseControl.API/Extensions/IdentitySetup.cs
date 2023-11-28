using ExpenseControl.Domain.Entities.Identity;
using ExpenseControl.Infra.Context;
using Microsoft.AspNetCore.Identity;

namespace ExpenseControl.API.Extensions
{
    public static class IdentitySetup
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<DatabaseContext>()
                    .AddDefaultTokenProviders();
        }
    }
}
