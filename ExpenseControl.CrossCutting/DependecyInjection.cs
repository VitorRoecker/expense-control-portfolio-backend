using ExpenseControl.Application.Interfaces;
using ExpenseControl.Application.Services;
using ExpenseControl.Domain.Interfaces.Services;
using ExpenseControl.Domain.Services;
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

            #endregion
        }

        private static void ConfigureDomainServices(IServiceCollection services)
        {
            #region Scoped

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            #endregion

            #region Singleton

            services.AddSingleton<IJwtService, JwtService>();
            
            #endregion
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
        }
    }
}