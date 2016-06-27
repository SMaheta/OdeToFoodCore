using OdeToFoodCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodCore.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentGreeting { get; set; }
    }
}
