using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10251131_PROG6221_POE_FINAL
{
    public class RecipeHandler
    {
        // Generic Collections
        private ICollection<Recipe> recipes;

        public delegate void ExceedCaloriesNotificationHandler(string recipeName, int totalCalories);
        // Alert is shown when displayrecipe option is picked, and not when the recipe and calories is being entered.

        public RecipeHandler()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe()
        {  // Prompt user for Recipe details
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            Recipe recipe = new Recipe(name);
            recipe.EnterDetails();

            recipes.Add(recipe);

            Console.WriteLine("Recipe added successfully.");
            Console.WriteLine();
        }

        public void DisplayAllRecipes()
        { //Displays all Recipe NAMES from collection/list
            Console.WriteLine("List of Recipes:");
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
            }
            else
            {
                var sortedRecipes = recipes.OrderBy(r => r.Name);
                foreach (Recipe recipe in sortedRecipes)
                {
                    Console.WriteLine(recipe.Name);
                    Console.WriteLine();
                }
            }
        }

        public void ScaleRecipe(double factor)
        {  //Scales Recipe
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
            }
            else
            {
                recipe.ScaleRecipe(factor);
                Console.WriteLine("Recipe scaled successfully.");
                Console.WriteLine();
            }
        }

        public void ResetQuantities()
        {
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();


            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
            }
            else
            {
                recipe.ResetQuantities();
                Console.WriteLine("Quantities reset successfully.");
                Console.WriteLine();
            }
        }

        public void ClearRecipe()
        { // clears recipe of which name is entered
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
            }
            else
            {
                recipes.Remove(recipe);
                Console.WriteLine("Recipe cleared successfully.");
                Console.WriteLine();
            }
        }
        public void DisplayRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            //Recipe displayed in Alphabetical order
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
            }
            else
            {
                recipe.DisplayRecipe();

                int totalCalories = recipe.CalculateTotalCalories();
                Console.WriteLine($"Total Calories: {totalCalories}");
                // Calorie Calculator
                if (totalCalories > 300)
                { // Calorie Delegate 
                  // Alert displayed when calories is more than 300 as well other recipe choices <300
                    Console.WriteLine("THIS RECIPE EXCEEDS 300 CALORIES!!!");
                    Console.WriteLine("for recipe ideas that are <300 calories check out this link below");
                    Console.WriteLine("https://www.bbcgoodfood.com/recipes/collection/300-calorie-meal-recipes");
                }
            }
        }
    }
}
