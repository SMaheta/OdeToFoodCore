using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodCore.Controllers
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+!-555-555-5555";
        }

        [Route("[action]")]
        public string Country()
        {
            return "USA";
        }
    }
}
