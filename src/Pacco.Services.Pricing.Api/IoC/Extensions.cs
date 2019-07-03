using Chronicle;
using Convey;
using Microsoft.Extensions.DependencyInjection;
using Pacco.Services.Pricing.Api.Core.Repositories;
using Pacco.Services.Pricing.Api.Core.Services;
using Pacco.Services.Pricing.Api.Mongo.Repositories;

namespace Pacco.Services.Pricing.Api.IoC
{
    public static class Extensions
    {
        public static IConveyBuilder RegisterComponents(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<ICustomersRepository, CustomersMongoRepository>();
            builder.Services.AddSingleton<ICustomerDiscountsService>(new CustomerDiscountsService());
            builder.Services.AddChronicle();

            return builder;
        }
    }
}