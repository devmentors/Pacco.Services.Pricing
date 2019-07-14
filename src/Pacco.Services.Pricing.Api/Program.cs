using System.Threading.Tasks;
using Convey;
using Convey.Logging;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Pacco.Services.Pricing.Api.DTO;
using Pacco.Services.Pricing.Api.IoC;
using Pacco.Services.Pricing.Api.Queries;

namespace Pacco.Services.Pricing.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddOpenTracing()
                    .AddConvey()
                    .AddWebApi()
                    .AddInfrastructure()
                    .Build())
                .Configure(app => app
                    .UseInfrastructure()
                    .UseDispatcherEndpoints(endpoints => endpoints
                        .Get("", ctx => ctx.Response.WriteAsync("Welcome to Pacco Pricing Service!"))
                        .Get<GetOrderPricing, OrderPricingDto>("pricing")
                    ))
                .UseLogging()
                .Build()
                .RunAsync();
    }
}
