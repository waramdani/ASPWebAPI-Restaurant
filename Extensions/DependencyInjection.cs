using Interface;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Extensions
{
    public static class DependencyInjection
    {

        public static void AddRestaurantRepositoryService(this IServiceCollection service) {

            service.AddScoped<IRestaurantRepository, RestaurantService>();


        }

    }
}