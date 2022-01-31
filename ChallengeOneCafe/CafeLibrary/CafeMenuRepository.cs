using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeLibrary
{
    public class CafeMenuRepository
    {
        private readonly List<CafeMenuContent> _repo = new List<CafeMenuContent>();
        // private readonly List<string> _ingredients = new List<string>();

        /* CRUD */

        // CREATE
        public bool AddContentToRepository(CafeMenuContent content)
        {
            int startingCount = _repo.Count;
            _repo.Add(content);

            return _repo.Count > startingCount;
        }

        // // Add ingredient to list of ingredients
        // public bool AddIngredientToList (string ingredient)
        // {
        //     int startingCount = _ingredients.Count;
        //     _ingredients.Add(ingredient);
        //     return _ingredients.Count > startingCount;
        // }

        // READ
        // get all
        public List<CafeMenuContent> GetContents()
        {
            return _repo;
        }

        // get by name
        public CafeMenuContent GetContentByName(string name)
        {
            foreach (CafeMenuContent target in _repo)
            {
                if (target.Name.ToLower() == name.ToLower())
                {
                    return target;
                }
            }
            return null;
        }
    

        // UPDATE
        public bool UpdateExistingContent(string originalName, CafeMenuContent newContent)
        {
            CafeMenuContent oldContent = GetContentByName(originalName);

            if (oldContent != null)
            {
                oldContent.MealNumber = newContent.MealNumber;
                oldContent.Name = newContent.Name;
                oldContent.Description = newContent.Description;
                oldContent.Ingredients = newContent.Ingredients;
                oldContent.Price = newContent.Price;

                return true;
            }
            return false;
        }


        // DELETE
        public bool DeleteExistingContent(CafeMenuContent existingContent)
        {
            return _repo.Remove(existingContent);
        }
    }
}