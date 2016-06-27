using Microsoft.AspNet.Mvc;
using OdeToFoodCore.Services;

namespace OdeToFoodCore.ViewComponents
{
    public class Greeting : ViewComponent
    {
        private IGreeeter _greeter;

        public Greeting(IGreeeter greeter) {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke() {
            var model = _greeter.GetGreetings();

            return View("default",model);
        }
    }
}
