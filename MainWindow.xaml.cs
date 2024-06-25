using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Linq;

namespace ST10251131_PROG6221_POE_FINAL
{
    public partial class MainWindow : Window
    {
        private TextWindow _textWindow;
        private List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();

            _textWindow = new TextWindow(UpdateOutput);
            Console.SetOut(_textWindow);
        }

        private void UpdateOutput(string text)
        {
            Dispatcher.Invoke(() =>
            {
                ConsoleOutputTextBox.Text += text;
            });
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow();
            addRecipeWindow.ShowDialog();

            if (addRecipeWindow.DialogResult.HasValue && addRecipeWindow.DialogResult.Value)
            {
                var recipe = new Recipe(addRecipeWindow.RecipeName);
                recipe.Ingredients = addRecipeWindow.Ingredients;
                recipe.Steps = addRecipeWindow.Steps;

                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Unit = addRecipeWindow.Unit;
                    ingredient.FoodGroup = addRecipeWindow.FoodGroup;
                    ingredient.Calories = addRecipeWindow.Calories;
                }

                recipes.Add(recipe);

                MessageBox.Show("Recipe added successfully!");
            }
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            foreach (var recipe in recipes)
            {
                var displayRecipeWindow = new DisplayRecipeWindow(recipe);
                displayRecipeWindow.ShowDialog();
            }
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecipe = GetSelectedRecipe();
            if (selectedRecipe != null)
            {
                recipes.Remove(selectedRecipe);
                MessageBox.Show("Recipe cleared successfully!");
            }
        }

        private void DisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count > 0)
            {
                var recipeNames = string.Join(Environment.NewLine, recipes.Select(recipe => recipe.Name));
                MessageBox.Show("All Recipe Names:" + Environment.NewLine + recipeNames, "Recipe Manager");
            }
            else
            {
                MessageBox.Show("No recipes found.", "Recipe Manager");
            }
        }

        private Recipe GetSelectedRecipe()
        {
            var selectedRecipeIndex = RecipeListBox.SelectedIndex;
            if (selectedRecipeIndex >= 0 && selectedRecipeIndex < recipes.Count)
            {
                return recipes[selectedRecipeIndex];
            }
            return null;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
