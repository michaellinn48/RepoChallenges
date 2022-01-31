using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeLibrary;
using CafeUI.Consoles;

namespace CafeUI
{
    public class UserInterface
    {
        private readonly IConsole _console;
        private readonly CafeMenuRepository _repo = new CafeMenuRepository();
        
        public UserInterface(IConsole console)
        {
            _console = console;
        }
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                _console.Clear();

                _console.WriteLine(
                    "Enter the number of your selection: \n" +
                    "1. Display all menu items \n" +
                    "2. Create new menu item \n" +
                    "3. Update menu item \n" +
                    "4. Delete menu item \n" +
                    "5. Exit"
                );

                string userSelection = _console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        DisplayAllContent();
                        break;

                    case "2":
                        AddNewContent();
                        break;

                    case "3":
                        UpdateExistingContent();
                        break;

                    case "4":
                        RemoveExistingContent();
                        break;

                    case "5":
                        _console.WriteLine("goodbye");
                        isRunning = false;
                        break;

                    default:
                        break;
                }
            }
        }

        /* DISPLAY ALL CONTENT */
        private void DisplayAllContent()
        {
            _console.Clear();

            List<CafeMenuContent> listOfContent = _repo.GetContents();

            foreach (CafeMenuContent content in listOfContent)
            {
                PrintContent(content);
            }

            _console.WriteLine("Press any key to continue...");
            _console.ReadKey();
        }

        /* ADD NEW CONTENT */
        private void AddNewContent()
        {
            _console.Clear();

            CafeMenuContent content = new CafeMenuContent();

            // meal number
            _console.WriteLine("Enter the meal number: ");
            content.MealNumber = int.Parse(_console.ReadLine());

            // name
            _console.WriteLine("Enter the meal name: ");
            content.Name = _console.ReadLine();


            // description
            _console.WriteLine("Enter the meal description: ");
            content.Description = _console.ReadLine();

            // ingredients
            bool isEnteringIngredients = true;

            _console.WriteLine("Enter an ingredient, or type 'done' when finished entering ingredients: ");

            while (isEnteringIngredients)
            {

                string ingredientEntry = _console.ReadLine();

                if (ingredientEntry == "done")
                {
                    isEnteringIngredients = false;
                }
                else
                {
                    content.Ingredients.Add(ingredientEntry);
                    _console.WriteLine("Enter another ingredient or type 'done' when finished: ");
                }
            }


            // price
            _console.WriteLine("Enter the price of the meal: ");
            content.Price = decimal.Parse(_console.ReadLine());

            _repo.AddContentToRepository(content);
        }

        /* UPDATE CONTENT */
        private void UpdateExistingContent()
        {
            _console.Clear();

            // Select What Content to Update
            _console.WriteLine("Enter the Name of the meal you want to update: ");
            string updateTarget = _console.ReadLine();
            CafeMenuContent content = _repo.GetContentByName(updateTarget);

            //Get Content to update it with
            CafeMenuContent newContent = new CafeMenuContent();

            // new meal number
            _console.WriteLine("Enter the new meal number: ");
            newContent.MealNumber = int.Parse(_console.ReadLine());

            // new name
            _console.WriteLine("Enter the new meal name: ");
            newContent.Name = _console.ReadLine();

            // new description
            _console.WriteLine("Enter the new meal description: ");
            newContent.Description = _console.ReadLine();

            // new ingredients
            bool isEnteringIngredients = true;

            _console.WriteLine("Enter an ingredient, or type 'done' when finished entering ingredients: ");

            while (isEnteringIngredients)
            {

                string ingredientEntry = _console.ReadLine();

                if (ingredientEntry == "done")
                {
                    isEnteringIngredients = false;
                }
                else
                {
                    newContent.Ingredients.Add(ingredientEntry);
                    _console.WriteLine("Enter another ingredient or type 'done' when finished: ");
                }
            }

            // new price
            _console.WriteLine("Enter the new price of the meal: ");
            newContent.Price = decimal.Parse(_console.ReadLine());

            //Repo Update method
            bool success = _repo.UpdateExistingContent(updateTarget, newContent);
            if (success)
            {
                _console.WriteLine("Content successfully updated.");
            }
            else
            {
                _console.WriteLine("Something went wrong");
            }
            _console.WriteLine("Press any key to continue");
            _console.ReadKey();

        }

        /* DELETE METHOD */
        private void RemoveExistingContent()
        {
            _console.Clear();

            //Listing all content and letting user pick one
            _console.WriteLine("Select the Meal you want to remove:");

            List<CafeMenuContent> contentList = _repo.GetContents();
            int counter = 1;

            foreach (CafeMenuContent content in contentList)
            {
                _console.WriteLine(counter + ". " + content.Name);
                counter++;
            }

            int contentSelection = int.Parse(_console.ReadLine());
            int targetIndex = contentSelection - 1;

            //check for valid selection
            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                CafeMenuContent targetContent = contentList[targetIndex];

                if(_repo.DeleteExistingContent(targetContent))
                {
                    //Code for success
                    _console.WriteLine($"{targetContent.Name} was removed");
                }
                else
                {
                    _console.WriteLine("Something went wrong");
                }
            }
            else
            {
                //Invalid Selection
                _console.WriteLine("Invalid Selection");
            }

            //Potentially replace with helper method
            _console.WriteLine("Press any key to continue...");
            _console.ReadKey();
        }

        /* HELPER PRINT METHOD */
        private void PrintContent(CafeMenuContent content)
        {
            _console.WriteLine(
                $"Meal Number: {content.MealNumber} \n" +
                $"Name: {content.Name} \n" +
                $"Description: {content.Description} \n" +
                "Ingredients: "
            );

            foreach (string ingredient in content.Ingredients)
            {
                _console.WriteLine($"{ingredient}");
            }

            _console.WriteLine($"Price: ${content.Price}\n\n");
        }

    }
}