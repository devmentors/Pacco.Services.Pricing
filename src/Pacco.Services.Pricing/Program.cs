using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pacco.Services.Pricing.DTO;
using Pacco.Services.Pricing.Events.Customers;
using Pacco.Services.Pricing.Events.Orders;
using Pacco.Services.Pricing.IoC;
using Pacco.Services.Pricing.Mongo.Documents;
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
                    .TestSaga()
                    .UseEndpoints(endpoints => endpoints
                        .Get("", ctx => ctx.Response.WriteAsync("Welcome to Pacco Pricing Service!")))
                    .UseDispatcherEndpoints(endpoints =>
                    {
                        endpoints.Get<GetOrderPricing, OrderPricingDto>("pricing");
                    }))
                .Build()
                .RunAsync();
    }

    public static class Extensions
    {
        public static IApplicationBuilder TestSaga(this IApplicationBuilder app)
        {
            var eventDispatcher = app.ApplicationServices.GetService<IEventDispatcher>();

            var customerId = Guid.NewGuid();
            eventDispatcher.PublishAsync(new CustomerCreated(customerId)).GetAwaiter().GetResult();
            eventDispatcher.PublishAsync(new OrderCompleted(Guid.Empty, customerId)).GetAwaiter().GetResult();
            eventDispatcher.PublishAsync(new OrderCompleted(Guid.Empty, customerId)).GetAwaiter().GetResult();

            return app;
        }
    }
}
