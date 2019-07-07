using System.Threading.Tasks;
using Convey;
using Convey.Logging;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Pacco.Services.Pricing.DTO;
using Pacco.Services.Pricing.IoC;
using Pacco.Services.Pricing.Queries;

namespace Pacco.Services.Pricing
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
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
