using System;
using Chronicle;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.Discovery.Consul;
using Convey.HTTP;
using Convey.LoadBalancing.Fabio;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pacco.Services.Pricing.Api.Core.Repositories;
using Pacco.Services.Pricing.Api.Core.Services;
using Pacco.Services.Pricing.Api.Events.Customers;
using Pacco.Services.Pricing.Api.Events.Orders;
using Pacco.Services.Pricing.Api.Mongo.Documents;
using Pacco.Services.Pricing.Api.Mongo.Repositories;

namespace Pacco.Services.Pricing.Api.IoC
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<ICustomersRepository, CustomersMongoRepository>();
            builder.Services.AddSingleton<ICustomerDiscountsService>(new CustomerDiscountsService());
            builder.Services.AddChronicle();

            return builder
                .AddQueryHandlers()
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddInMemoryQueryDispatcher()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher()
                .AddMongo()
                .AddMongoRepository<CustomerDocument, Guid>("Clients")
                .AddHttpClient()
                .AddConsul()
                .AddFabio()
                .AddRabbitMq();
        }
        
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseInitializers()
                .UseConsul()
                .UseRabbitMq()
                .SubscribeEvent<CustomerCreated>()
                .SubscribeEvent<OrderCompleted>();

            return app;
        }
    }
}