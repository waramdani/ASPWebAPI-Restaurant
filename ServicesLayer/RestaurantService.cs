using RestaurantApp_AspMVC.Data;
using RestaurantApp_AspMVC.Interface;
using RestaurantApp_AspMVC.Models;

namespace RestaurantApp_AspMVC.Services
{
    public class RestaurantService : IRestaurantRepository
    {
        private readonly List<Restaurant> _restaurants;
        public RestaurantService() {
            var restaurantData = new RestaurantData();
            _restaurants = restaurantData.Restaurants;
        }


        public void AddRestaurant(Restaurant restaurant)
        {
            //restaurant.Id = _restaurants.Count + 1;
            _restaurants.Add(restaurant);
        }
        public void DeleteRestaurant(int id)
        {
            var index = _restaurants.FindIndex(r => r.Id == id);
            if (index != -1)
            {
                _restaurants.RemoveAt(index);
            }
        }
        public IEnumerable<Restaurant> GetAllRestaurants() =>_restaurants;
        public Restaurant GetRestaurantById(int id)
        {
           return _restaurants.FirstOrDefault(r => r.Id == id);
        }
        public void UpdateRestaurant(Restaurant restaurant)
        {
            var index = _restaurants.FindIndex(r => r.Id == restaurant.Id);
            if (index != -1)
            {
                _restaurants[index] = restaurant;
            }
        }
    }
}
