using System.Collections.Generic;
using System.Windows;

namespace ST10251131_PROG6221_POE_FINAL
{
    public partial class AddRecipeWindow : Window
    {
        public string RecipeName { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<string> Steps { get; set; }
        public string RecipeDetails { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
        public string Unit { get; set; }    

        public AddRecipeWindow()
        {
            InitializeComponent();
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the entered values from the respective TextBoxes
            RecipeName = RecipeNameTextBox.Text;
            Calories = int.Parse(CaloriesTextBox.Text);
            FoodGroup = FoodGroupTextBox.Text;
            Unit = UnitTextBox.Text;

            var ingredientLines = IngredientsTextBox.Text.Split('\n');
            foreach (var line in ingredientLines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 2)
                {
                    var quantity = double.Parse(parts[1]);
                    var unit = UnitTextBox.Text;
                    Ingredients.Add(new Ingredient(parts[0], quantity, unit, Calories, FoodGroup));
                }
            }

            // Process the steps data
            var stepLines = StepsTextBox.Text.Split('\n');
            foreach (var line in stepLines)
            {
                Steps.Add(line);
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
