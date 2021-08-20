using Challange1_Class_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange_1.UI
{
    public class ProgramUI
    {
        private readonly MenuRepository _repo = new MenuRepository();
        private int _menuNumber = 4;
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            List<string> sandwich = new List<string>() { "Bread", "Meat", "Cheese", "Vegetables" };
            List<string> pastry = new List<string>() { "Sugar", "Icing", "Flour", "Eggs", "Milk" };
            Menu club = new Menu(1, "Club SandWich", "A classic club sandwich on toasted bread", sandwich, 9.99);
            Menu cupcake = new Menu(2, "Cupcake", "Eating a cupcake as a meal? Definietly.", pastry, 4.99);
            Menu muffin = new Menu(3, "Muffin", "Its a muffin with another muffin inside of it", pastry, 13.49);

            _repo.AddMenuItem(club);
            _repo.AddMenuItem(cupcake);
            _repo.AddMenuItem(muffin);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu:\n" +
                        "1. Add Menu Item\n" +
                        "2. Show all Menu Items\n" +
                        "3. Delete Menu Item\n" +
                        "4. Exit\n");
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                    case "add":
                    case "add menu item":
                        AddMenuItem();
                        break;
                    case "2":
                    case "show":
                    case "show all menu items":
                        ShowAllItems();
                        break;
                    case "3":
                    case "delete":
                    case "delete menu item":
                        DeleteItem();
                        break;
                    case "4":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        ContinueMessage();
                        break;
                }
            }
        }
        public void AddMenuItem()
        {
            Console.Clear();
            bool properPrice = false;
            //Menu Number
            int menuNumber = _menuNumber;
            _menuNumber++;
            //Name
            Console.WriteLine("What is the name of the new item?");
            string name = Console.ReadLine();
            //Description
            Console.WriteLine("What is a desctiption of the new item?");
            string description = Console.ReadLine();
            //Ingredients
            List<string> ingredients = GetIngredients();
            //Price
            Console.WriteLine("What is the price of the new item?");
            double price = 0;
            while (!properPrice)
                try
                {
                    price = Math.Round(double.Parse(Console.ReadLine()),2);
                    properPrice = true;
                }
                catch
                {
                    Console.WriteLine("You must enter a number");
                }
            //Add Item
            Menu newItem = new Menu(menuNumber, name, description, ingredients, price);
            _repo.AddMenuItem(newItem);
        }

        public void ShowAllItems()
        {
            Console.Clear();
            List<Menu> menuItems = _repo.GetMenuItems();
            foreach(Menu menu in menuItems)
            {
                Console.WriteLine($"#{menu.MenuNumber} {menu.MealName}\n{menu.Description}\nIngredients: {string.Join(", ",menu.Ingredients)}\nPrice: ${menu.Price}\n\n");
            }
            ContinueMessage();
        }

        public void DeleteItem()
        {
            Console.Clear();
            Console.Write("Enter the menu number that you want to delete: ");
            bool aNumber = false;
            int id = 0;
            while(!aNumber)
            {
                try
                {
                    id = int.Parse(Console.ReadLine());
                    aNumber = true;
                }
                catch
                {
                    Console.WriteLine("You must enter a number");
                }
            }
            Menu itemToDelete = _repo.GetMenuItemByID(id);
            if (itemToDelete == null)
            {
                Console.WriteLine("No menu item with that number found.");
            }
            else
            {
                _repo.DeleteMenuItems(itemToDelete);
            }
        }

        public List<string> GetIngredients()
        {
            Console.WriteLine("Enter Ingredients 1 at a time. Enter 'Done' when done.");
            List<string> ingredients = new List<string>();
            bool moreIngredients = true;
            while (moreIngredients)
            {
                Console.Write("Ingredient: ");
                string individualIngredient = Console.ReadLine();
                if (individualIngredient == "done" || individualIngredient == "Done")
                {
                    moreIngredients = false;
                }
                else
                {
                    ingredients.Add(individualIngredient);
                }
            }
            return ingredients;
        }

        public void ContinueMessage()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
