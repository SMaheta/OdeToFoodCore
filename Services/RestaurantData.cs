using OdeToFoodCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get( int id );
        void Add(Restaurant restaurant);
    }


    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public void Add(Restaurant restaurant)
        {
          _context.Add(restaurant);
          _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }
    }


    public class InMemoryRestaurantData : IRestaurantData
    {
        static private List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant> 
            {
                new Restaurant {Id=1,Name ="Tersiguel's" },
                new Restaurant {Id=2,Name ="Lj's and the kat" },
                new Restaurant {Id=3,Name ="King's Contrivance" },
                new Restaurant {Id=4,Name ="Jackel and fox" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);
        }
    }
}
