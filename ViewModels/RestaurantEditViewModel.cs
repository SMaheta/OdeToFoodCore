using OdeToFoodCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodCore.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]        
        [Display(Name="Restaurant Name")]
        public string Name { get; set; }
        public Cuisinetype Cuisine { get; set; }
    }
}
