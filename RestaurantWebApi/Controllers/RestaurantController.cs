using Microsoft.AspNetCore.Mvc;
using RestaurantApp_AspMVC.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurant;

        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            _restaurant = restaurantRepository;
        }

        // GET: api/<RestaurantController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
          
            return (IEnumerable<string>)Ok(_restaurant.GetAllRestaurants());
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
