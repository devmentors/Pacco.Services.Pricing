using Convey;
using Convey.CQRS.Queries;
using Convey.Discovery.Consul;
using Convey.HTTP;
using Convey.LoadBalancing.Fabio;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pacco.Services.Pricing.Core.Services;
using Pacco.Services.Pricing.Services.Clients;

namespace Pacco.Services.Pricing.IoC
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
                .AddFabio();
        }
        
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseInitializers()
                .UseConsul();

            return app;
        }
    }
}