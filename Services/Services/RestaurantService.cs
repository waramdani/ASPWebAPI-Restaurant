
using Dbcontext;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class RestaurantService : IRestaurantRepository
    {
        private readonly RestaurantContext _dbContext;
        public RestaurantService(RestaurantContext restaurantContext)
        {
            _dbContext = restaurantContext;
        }
        public void AddRestaurant(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
        }
        public void DeleteRestaurant(int id)
        {
            var restaurant=_dbContext.Restaurants.Find(id);
            if(restaurant != null)
            { 
                _dbContext.Restaurants.Remove(restaurant);
                _dbContext.SaveChanges();
            }
        }
        public IEnumerable<Restaurant> GetAllRestaurants() {

            var result = _dbContext.Restaurants.Include(r => r.Cuisines).ToList();
            return result;
                }
        public Restaurant GetRestaurantById(int id)
        {
            return _dbContext.Restaurants.Include(r => r.Cuisines).FirstOrDefault(r => r.Id == id);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _dbContext.Restaurants.Update(restaurant);
            _dbContext.SaveChanges();
        }
    }
}
