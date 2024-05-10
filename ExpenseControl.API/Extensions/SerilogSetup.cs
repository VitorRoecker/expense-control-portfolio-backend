using Serilog;

namespace ExpenseControl.API.Extensions
{
    public static class SerilogSetup
    {
        public static IHostBuilder ConfigureLogging(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders().AddSerilog();

            return builder.Host.UseSerilog((context, cfg)
                => cfg.ReadFrom.Configuration(context.Configuration));
        }
    }
}
