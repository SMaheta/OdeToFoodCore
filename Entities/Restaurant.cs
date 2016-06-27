﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdeToFoodCore.Entities
{
    public enum Cuisinetype
    {
        None,
        Italian,
        French,
        american
    }

    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]        
        [Display(Name="Restaurant Name")]
        public string Name { get; set; }
        public Cuisinetype Cuisine {get;set; }
    }
}
