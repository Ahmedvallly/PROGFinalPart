using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10251131_PROG6221_POE_FINAL
{
    public class Recipe
    {
        public string Name { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<string> Steps { get; set; }
        public string Details { get; set; }
        public string FoodGroup { get; set; } // Added property for food group
        public int Calories { get; set; } // Added property for calories



    public Recipe(string name)
            {
                Name = name;
                Ingredients = new List<Ingredient>();
                Steps = new List<string>();
                Details = string.Empty;
                FoodGroup = string.Empty;
                Calories = 0;
        }
            //Prompts user for recipe details
            public void EnterDetails()
            {
                Console.Write("Enter the number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Quantity: ");
                    double quantity = double.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Unit of measurement: ");
                    string unit = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Please provide the nutritional information for the ingredient such as calorie amount and food group :");

                    string foodGroup = GetFoodGroup();

                    Console.Write("Calories (A measurement of the energy content of food): ");
                    int calories = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
                }


                Console.Write("Enter the number of steps: ");
                int numSteps = int.Parse(Console.ReadLine());
                Console.WriteLine();

                for (int i = 0; i < numSteps; i++)
                {
                    Console.Write($"Enter step #{i + 1}: ");
                    Steps.Add(Console.ReadLine());
                    Console.WriteLine();
                }
            }

            private static string GetFoodGroup()
            {
                while (true)
                { //Menu of all the different food group tyes
                    Console.WriteLine("Select the food group from the following options:");
                    Console.WriteLine("1. Fruits");
                    Console.WriteLine("2. Vegetables");
                    Console.WriteLine("3. Grains");
                    Console.WriteLine("4. Proteins");
                    Console.WriteLine("5. Dairy");
                    Console.WriteLine("6. Fats and Oils");
                    Console.WriteLine("7. Unknown");
                    Console.WriteLine();
                    Console.Write("Enter the food group number: ");
                    int foodGroupOption = int.Parse(Console.ReadLine());

                    switch (foodGroupOption)
                    {
                        case 1:
                            return "Fruits";
                        case 2:
                            return "Vegetables";
                        case 3:
                            return "Grains";
                        case 4:
                            return "Proteins";
                        case 5:
                            return "Dairy";
                        case 6:
                            return "Fats and Oils";
                        case 7:
                            return "Unknown";
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            break;
                            // Invalid option prompt if user enters invalid number
                    }
                }
            }

            public void DisplayRecipe()
            { //Displays recipe with all info
                Console.WriteLine($"Recipe: {Name}");
                Console.WriteLine();

                Console.WriteLine("Ingredients:");
                Console.WriteLine();
                foreach (Ingredient ingredient in Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                    Console.WriteLine();
                }

                Console.WriteLine("Food Groups:");
                foreach (Ingredient ingredient in Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Name}: {ingredient.FoodGroup}");
                    Console.WriteLine();
                }

                Console.WriteLine("Steps:");
                foreach (string step in Steps)
                {
                    Console.WriteLine($"- {step}");
                    Console.WriteLine();
                }
            }

            public void ScaleRecipe(double factor)
            {
                foreach (Ingredient ingredient in Ingredients)
                {
                    ingredient.Quantity *= factor;
                }
            }

            public void ResetQuantities()
            {
                foreach (Ingredient ingredient in Ingredients)
                {
                    ingredient.ResetQuantity();
                }
            }

            public int CalculateTotalCalories()
            { //Unit tested for different outcomes such as; 0 and negative calorie number.
                int totalCalories = 0;
                foreach (Ingredient ingredient in Ingredients)
                {
                    if (ingredient.Calories >= 0)
                    {
                        totalCalories += ingredient.Calories;
                    }
                }
                return totalCalories >= 0 ? totalCalories : 0;
            }
        }

    }

