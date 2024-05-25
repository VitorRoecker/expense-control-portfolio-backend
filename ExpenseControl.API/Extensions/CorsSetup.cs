namespace ExpenseControl.API.Extensions
{
    public static class CorsSetup
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors();
        }
    }
}
