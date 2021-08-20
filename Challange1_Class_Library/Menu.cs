using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange1_Class_Library
{
    public class Menu
    {

        //Fields?? 

        //Properties 
        public int MenuNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<String> Ingredients { get; set; }
        public double Price { get; set; }

        //Constructors
        public Menu() { }
        public Menu(int menuNumber, string mealName, string description, List<string> ingredients, double price)
        {
            MenuNumber = menuNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
