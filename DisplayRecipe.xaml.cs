using System.Collections.Generic;
using System.Windows;

namespace ST10251131_PROG6221_POE_FINAL
{
    public partial class DisplayRecipeWindow : Window
    {
        private Recipe recipe;

        public DisplayRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            DisplayRecipe();
        }

        private void DisplayRecipe()
        {
            RecipeTitleTextBlock.Text = $"Recipe: {recipe.Name}";

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                IngredientsListBox.Items.Add($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                FoodGroupsListBox.Items.Add($"{ingredient.Name}: {ingredient.FoodGroup}");
            }

            foreach (string step in recipe.Steps)
            {
                StepsListBox.Items.Add(step);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
