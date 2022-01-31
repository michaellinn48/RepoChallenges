using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeLibrary
{
    public class CafeMenuContent
    {
        public CafeMenuContent() {}
        public CafeMenuContent(int mealNumber, string name, string description, List<string> ingredients, decimal price)
        {
            MealNumber = mealNumber;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        public int MealNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public decimal Price { get; set; }

    }
}