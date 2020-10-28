using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Datadog.Logs;

namespace Serilog_sink_datadog_logs_AAS_AspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new DatadogConfiguration("https://http-intake.logs.datadoghq.com");

            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.DatadogLogs(
                    "<API_KEY>",
                    configuration: config
                )
                .Enrich.FromLogContext()
                .CreateLogger();

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed.");
                throw;

            }finally
            {
                Log.CloseAndFlush();
            }


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() // avaliable in Serilog.Extensions.Hosting NuGet
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
