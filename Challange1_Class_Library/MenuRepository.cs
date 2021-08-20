using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange1_Class_Library
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menuDirectory = new List<Menu>();

        //CRUD
        // Create
        public bool AddMenuItem(Menu menu)
        {
            int count = _menuDirectory.Count();
            _menuDirectory.Add(menu);
            bool addedItem = _menuDirectory.Count() > count;
            return addedItem;
        }
        //Read
        public List<Menu> GetMenuItems()
        {
            return _menuDirectory;
        }
        //Update
        //Delete
        public bool DeleteMenuItems(Menu menuItem)
        {
            bool deleteResult = _menuDirectory.Remove(menuItem);
            return deleteResult;
        }

    }
}
