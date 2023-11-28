namespace ExpenseControl.API.Extensions
{
    public static class CorsSetup
    {
        public static void ConfigureCors(this IServiceCollection services, string origins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: origins, policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                }); 
            });
        }
    }
}
