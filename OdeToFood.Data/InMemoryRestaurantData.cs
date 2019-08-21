using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
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

        public Restaurant Add(Restaurant restaurant)
        {
            if (restaurant != null)
            {
                restaurants.Add(restaurant);
                restaurant.Id = restaurants.Max(a => a.Id) + 1;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var res = restaurants.SingleOrDefault(a => a.Id == id);
            if (res != null)
            {
                restaurants.Remove(res);
            }
            return res;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(a => a.Name);
        }

        public Restaurant GetById(int id)
        {
            return restaurants.FirstOrDefault(a => a.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(a => string.IsNullOrEmpty(name) || a.Name.StartsWith(name))
                              .OrderBy(a => a.Name);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var res = restaurants.SingleOrDefault(a => a.Id == restaurant.Id);
            if (res != null)
            {
                res.Name = restaurant.Name;
                res.Location = restaurant.Location;
                res.Cuisine = restaurant.Cuisine;
            }
            return res;
        }
    }
}