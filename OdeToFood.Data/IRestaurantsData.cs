using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestrauntsByName(string name);

    }
    public class InMemoryRestaurantsData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantsData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Nazar`s pizza", Location = "Orlando", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Buritos", Location = "Los Santos", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Indian Island", Location = "Sun Fiero", Cuisine = CuisineType.Indian }
            };
        
        }

        public IEnumerable<Restaurant> GetRestrauntsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
