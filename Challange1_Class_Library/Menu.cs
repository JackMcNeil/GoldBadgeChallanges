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
        private int _menuNumber;
        private List<string> _Ingredients;
        //Properties 
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<String> Ingredients { get { return _Ingredients; } set { _Ingredients = value; } }
        public double Price { get; set; }
        public int MenuNumber { get => _menuNumber; set => _menuNumber = value; }

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
