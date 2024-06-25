# PROGFinalPart
 
prog6211---poe final part


Recipe App This Recipe App is a simple application that allows users to manage their recipes. It was originally developed as a console application and has been converted into a WPF application for a more user-friendly interface.

Features The Recipe Manager application provides the following features:

Add a Recipe: Users can add a new recipe by providing the recipe name, ingredients, and steps. Display a Recipe: Users can view the details of a selected recipe, including its ingredients and steps. Reset Quantities: Users can reset the quantities of ingredients in a selected recipe to their original values. Clear a Recipe: Users can remove a selected recipe from the list. Display All Recipe Names: Users can view a list of all the recipe names available in the application. Exit: Users can exit the application.

Updates and Improvements During the conversion from a console application to a WPF application, several updates and improvements were made:

User Interface: The application's user interface was redesigned using WPF controls, providing a more visually appealing and interactive experience for users. Text Window: A custom TextWindow class was created to redirect the application's console output to a WPF TextBox control named ConsoleOutputTextBox. This allows users to view the application's output within the WPF interface itself. Window Management: Different windows were created for specific actions, such as adding a recipe (AddRecipeWindow), displaying a recipe (DisplayRecipeWindow), and displaying all recipe names (TextWindow). This improves the user experience by separating different functionalities into distinct windows. Event Handling: Event handlers were implemented to respond to button clicks and perform the corresponding actions, such as adding a recipe, displaying a recipe, scaling a recipe, resetting quantities, clearing a recipe, and displaying all recipe names. Data Structures: The application uses a List to store and manage recipes, allowing for easy addition, retrieval, and manipulation of recipe data.

Getting Started To run the Recipe Manager application, follow these steps: Clone the repository or download the source code files. Open the solution file (RecipeManager.sln) in Visual Studio. Build the solution to restore dependencies and compile the application. Run the application by pressing F5 or selecting the "Start" button in Visual Studio. The Recipe Manager window will appear, and you can start interacting with the application's features.

Dependencies The Recipe Manager application has the following dependencies: .NET Framework 4.7.2 or higher Windows Presentation Foundation (WPF) Contributing Contributions to the Recipe Manager application are welcome. If you find any issues or have suggestions for improvements, please create an issue or submit a pull request.

License The Recipe Manager application is licensed under the MIT License.