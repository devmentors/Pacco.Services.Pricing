using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Convey;
using Convey.CQRS.Queries;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pacco.Services.Pricing.DTO;
using Pacco.Services.Pricing.Queries;

namespace Pacco.Services.Pricing
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddConvey()
                    .AddWebApi())
                .Configure(app => app
                    .UseEndpoints(endpoints => endpoints
                        .Get("", ctx => ctx.Response.WriteAsync("Welcome to Pacco Pricing Service!"))
                        .Get<GetOrderPricing, OrderPricingDto>("orders/{orderId}/pricing",
                            (query, ctx) =>
                            {
                                ctx.Response.WriteJson(new OrderPricingDto
                                {
                                    OrderId = query.OrderId,
                                    OrderPrice = query.OrderPrice,
                                    ClientDiscount = 250
                                });
                                
                                return Task.CompletedTask;
                            })))
                .Build()
                .RunAsync();
    }
}
