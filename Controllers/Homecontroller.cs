using Microsoft.AspNetCore.Mvc;
using OdeToFoodCore.ViewModels;
using OdeToFoodCore.Services;
using OdeToFoodCore.Entities;
using Microsoft.AspNet.Authorization;

namespace OdeToFoodCore.Controllers {

    
    public class HomeController : Controller {
        private IGreeeter _greeter;
        private IRestaurantData _restaurantdata;

        public HomeController(IRestaurantData restaurantdata, IGreeeter greeter) {
            _restaurantdata = restaurantdata;
            _greeter = greeter;
        }        
        public ViewResult Index() {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantdata.GetAll();
            model.CurrentGreeting = _greeter.GetGreetings();
            return View(model);
        }

        public IActionResult Details(int id) {
            var model = _restaurantdata.Get(id);
            if (model == null) {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ViewResult Create() {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var model = _restaurantdata.Get(id);
            if (model == null) {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id , RestaurantEditViewModel input) {
           var restaurant = _restaurantdata.Get(id);
            if(restaurant != null && ModelState.IsValid) 
            {
                restaurant.Name = input.Name;
                restaurant.Cuisine = input.Cuisine;

                return RedirectToAction("Details",new { id = restaurant.Id});
            }

            return View(restaurant);
        }
        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model) {
            if (ModelState.IsValid) {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;

                _restaurantdata.Add(restaurant);

                return RedirectToAction("Details", new { id = restaurant.Id.ToString() });
            }
            return View();
        }
    }
}
