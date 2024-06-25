using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10251131_PROG6221_POE_FINAL
{
    public class Ingredient
    {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            public double OriginalQuantity { get; set; }
            public int Calories { get; set; }
            public string FoodGroup { get; set; }

            public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
                OriginalQuantity = quantity;
                Calories = calories;
                FoodGroup = foodGroup;
            }
            // reset quantities back to original value
            public void ResetQuantity()
            {
                Quantity = OriginalQuantity;
            }
        }
    }

