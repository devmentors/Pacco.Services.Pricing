using Chronicle;
using Convey;
using Microsoft.Extensions.DependencyInjection;
using Pacco.Services.Pricing.Core.Repositories;
using Pacco.Services.Pricing.Core.Services;
using Pacco.Services.Pricing.Mongo.Repositories;

namespace Pacco.Services.Pricing.IoC
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