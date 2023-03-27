using RestaurantApp_AspMVC.Models;

namespace RestaurantApp_AspMVC.Interface
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurantById(int id);
        void AddRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int id);

    }
}
