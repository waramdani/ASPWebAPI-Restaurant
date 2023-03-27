using Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository _restaurant;

        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            _restaurant = restaurantRepository;
        }

        // GET: RestaurantController
        [Route("restaurant")]
        public ActionResult Index()
        {
            var restaurant= _restaurant.GetAllRestaurants();
            return View(restaurant);
        }

        // GET: RestaurantController/Details/5
        public ActionResult Details(int id)
        {
            var restaurant = _restaurant.GetRestaurantById(id);
            return View(restaurant);
        }

        // GET: RestaurantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                _restaurant.    AddRestaurant(restaurant);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(restaurant);
            }
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            var restaurant = _restaurant.GetRestaurantById(id);

            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Restaurant restaurant)
        {
            try
            {
                _restaurant.UpdateRestaurant(restaurant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(restaurant);
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            _restaurant.DeleteRestaurant(id);

            return View();
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Restaurant restaurant)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
