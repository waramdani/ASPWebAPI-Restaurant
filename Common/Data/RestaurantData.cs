
using Models;

namespace Data
{
    public class RestaurantData
    {
        public List<Restaurant> Restaurants { get; set; }
        public List<Cuisine> Cuisines { get; set; }

        public RestaurantData()
        {
            Restaurants = new List<Restaurant>
             {
                new Restaurant {
                   
                  Id = 1,
                  Name = "Restaurant A",
                  Address = "123 Main St",
                  Phone = "555-555-5555",
                
                     Cuisines= new List<Cuisine>
                    {
                        new Cuisine { Id = 1,Name="Cuisine 1"},
                        new Cuisine { Id = 2,Name="Cuisine 2"},
                    }
                },
            };
        }
    }
}
