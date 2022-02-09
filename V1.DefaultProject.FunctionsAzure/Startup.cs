using Azure.Identity;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using System;
using V1.DefaultProject.Config.Extension;
using V1.DefaultProject.FunctionsAzure;
using V1.DefaultProject.FunctionsAzure.Enum;
using V1.DefaultProject.FunctionsAzure.Util;

[assembly: FunctionsStartup(typeof(Startup))]
namespace V1.DefaultProject.FunctionsAzure
{
    public sealed class Startup : FunctionsStartup
    {
        private static readonly IConfigurationRoot _configuration = StartupConfig.Configuration;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureServices(builder.Services);
        }
        private void ConfigureServices(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.WithProperty("Application", "Sample.AzureFunctions.DotNet31")
                .Enrich.FromLogContext()
                .CreateLogger();

            services.AddSingleton<ILoggerProvider>(sp => new SerilogLoggerProvider(Log.Logger, true));

            services.AddLogging(lb => lb.AddSerilog(Log.Logger, true));

            services.AddSingleton(StartupConfig.Configuration);

            services.Configure<QueuesOptions>(options =>
            {
                DefaultProjectQueueOptions.SetQueuesOptions(options);

                Log.Information($"Startup.QueuesOptions: {options.Format()}.", "Startup");
            });

            services.ConfigureDbContext(_configuration);
            services.AddHttpContextAccessor();
            services.ConfigureAutomapper();
            services.ConfigureServices();
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            DefaultProjectThreadPool.SetMinThreads();

            Log.Information($"Startup.ASPNETCORE_ENVIRONMENT: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") }, " , "Startup");
        }

    }
}
