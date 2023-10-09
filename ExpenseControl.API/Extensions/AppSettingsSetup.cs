using ExpenseControl.Infra.External_Dependence;

namespace ExpenseControl.API.Extensions
{
    public static class AppSettingsSetup
    {
        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(options => configuration.GetSection("AppSettings").Bind(options));
        }
    }
}
