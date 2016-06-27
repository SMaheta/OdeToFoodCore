using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodCore.Services
{
    public interface IGreeeter
    {
        string GetGreetings();
    }
    public class Greeter : IGreeeter
    {
        private string _greeting;

        public Greeter(IConfiguration Configuration)
        {
            _greeting = Configuration["greeting"];
        }
        public string GetGreetings()
        {
            return _greeting;   
        }
    }
}
