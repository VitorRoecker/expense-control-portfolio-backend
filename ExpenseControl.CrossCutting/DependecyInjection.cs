using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.Services;
using ExpenseControl.Data.Repositories;
using ExpenseControl.Data.Repositories.Interfaces;
using ExpenseControl.Domain.Services.Interfaces.Services;
using ExpenseControl.Domain.Services.Interfaces.Services.Identity;
using ExpenseControl.Domain.Services.Services;
using ExpenseControl.Domain.Services.Services.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseControl.CrossCutting
{
    public static class DependencyInjection
    {
        public static void ConfigureDependecyInjection(this IServiceCollection services)
        {
            ConfigureDomainServices(services);
            ConfigureAppServices(services);
            ConfigureRepositories(services);
        }

        private static void ConfigureAppServices(IServiceCollection services)
        {
            #region Scoped

            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IExpenseAppService, ExpenseAppService>();
            services.AddScoped<IIncomeAppService, IncomeAppService>();

            #endregion
        }

        private static void ConfigureDomainServices(IServiceCollection services)
        {
            #region Scoped

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IIncomeService, IncomeService>();

            #endregion

            #region Singleton

            services.AddSingleton<IJwtService, JwtService>();
            
            #endregion
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            #region Scoped

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}