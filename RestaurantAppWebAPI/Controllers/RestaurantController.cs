using Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurant;
        ILogger logger;

        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            _restaurant = restaurantRepository;
        }

        // GET: api/<RestaurantController>
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>>Get()
        {
           return Ok( _restaurant.GetAllRestaurants());
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public  ActionResult<Restaurant> Get(int id)
        {
            var restaurant= _restaurant.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult Post([FromBody] Restaurant restaurant)
        {
            logger.LogInformation($"Received request to add restaurant: {JsonConvert.SerializeObject(restaurant)}");
            _restaurant.AddRestaurant(restaurant);
            return CreatedAtAction(nameof(Get), new {id= restaurant.Id}, restaurant);
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }
            _restaurant.UpdateRestaurant(restaurant);

            return NoContent();
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var restau=_restaurant.GetRestaurantById(id);
            if(restau == null)
            {
                return NotFound();
            }
             _restaurant.DeleteRestaurant(id);
            return Ok();
        }
    }
}
