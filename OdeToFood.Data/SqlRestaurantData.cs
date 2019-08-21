using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return _context.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = _context.Restaurants.Where(a => a.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                                            .OrderBy(a => a.Name);
            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = _context.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}