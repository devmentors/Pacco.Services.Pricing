using System;
using System.Threading.Tasks;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Pacco.Services.Pricing.Api.DTO;
using Pacco.Services.Pricing.Api.Mongo.Documents;
using Pacco.Services.Pricing.Api.Queries;
using Pacco.Services.Pricing.Api.IoC;

namespace Pacco.Services.Pricing.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddConvey()
                    .AddWebApi()
                    .RegisterComponents()
                    .AddQueryHandlers()
                    .AddCommandHandlers()
                    .AddEventHandlers()
                    .AddInMemoryQueryDispatcher()
                    .AddInMemoryCommandDispatcher()
                    .AddInMemoryEventDispatcher()
                    .AddMongo()
                    .AddMongoRepository<CustomerDocument, Guid>("Clients"))
                .Configure(app => app
                    .UseEndpoints(endpoints => endpoints
                        .Get("", ctx => ctx.Response.WriteAsync("Welcome to Pacco Pricing Service!")))
                    .UseDispatcherEndpoints(endpoints =>
                    {
                        endpoints.Get<GetOrderPricing, OrderPricingDto>("pricing");
                    }))
                .Build()
                .RunAsync();
    }
}
