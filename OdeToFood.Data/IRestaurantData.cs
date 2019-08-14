using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
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
    }
}
