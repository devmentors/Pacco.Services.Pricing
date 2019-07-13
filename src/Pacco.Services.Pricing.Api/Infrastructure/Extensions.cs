using Convey;
using Convey.Configurations.Vault;
using Convey.CQRS.Queries;
using Convey.Discovery.Consul;
using Convey.HTTP;
using Convey.LoadBalancing.Fabio;
using Convey.Metrics.AppMetrics;
using Convey.Tracing.Jaeger;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pacco.Services.Pricing.Api.Core.Services;
using Pacco.Services.Pricing.Api.Services.Clients;

namespace Pacco.Services.Pricing.Api.IoC
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<ICustomersServiceClient, CustomersServiceClient>();
            builder.Services.AddTransient<ICustomerDiscountsService, CustomerDiscountsService>();

            return builder
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddHttpClient()
                .AddConsul()
                .AddFabio()
                .AddMetrics()
                .AddJaeger()
                .AddVault();
        }
        
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseVault()
                .UseInitializers()
                .UseConsul()
                .UseMetrics();

            return app;
        }
    }
}