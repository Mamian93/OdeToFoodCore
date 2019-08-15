using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Dominno",
                    Cuisine = CuisineType.Italian,
                    Location = "Cracow"
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Bombi",
                    Cuisine = CuisineType.Indian,
                    Location = "Cracow"
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Turek",
                    Cuisine = CuisineType.None,
                    Location = "Wieliczka"
                },
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(a => a.Name);
        }

        public Restaurant GetById(int id)
        {
            return restaurants.FirstOrDefault(a => a.Id == id);
        }
        
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(a => string.IsNullOrEmpty(name) || a.Name.StartsWith(name))
                              .OrderBy(a => a.Name);
        }
    }
}