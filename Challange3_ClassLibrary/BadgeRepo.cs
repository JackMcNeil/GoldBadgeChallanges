using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange3_ClassLibrary
{
    public class BadgeRepo
    {
        protected readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        //Crud
        //C
        public bool AddNewBadge(Badge badge)
        {
            int startingCount = _badgeDictionary.Count();
            _badgeDictionary.Add(badge.BadgeId,badge.DoorNames);
            return _badgeDictionary.Count() > startingCount;
        }

        //R
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeDictionary;
        }

        public Badge GetBadgeById(int id)
        {
            Badge returnBadge = new Badge();
            Dictionary<int, List<string>> allItems = GetAllBadges();
            foreach(int item in allItems.Keys)
            {
                if (item == id)
                {
                    returnBadge.BadgeId = item;
                    returnBadge.DoorNames = _badgeDictionary[item];
                    return returnBadge;
                }
            }
            Console.WriteLine("No badge with that ID found. Press enter to continue...");
            //Console.ReadKey();
            return null;
        }

        //U
        public bool UpdateExistingBadge(int id, string door)
        {
            List<string> oldList = _badgeDictionary[id];
            bool inList = oldList.Contains(door);
            if (inList)
            {
                return false;
            }
            else
            {
                oldList.Add(door);
                _badgeDictionary[id] = oldList;
                return true;
            }
        }

        public bool RemoveExisitngDoor(int id, string door)
        {
            List<string> oldList = _badgeDictionary[id];
            bool inList = oldList.Contains(door);
            if (!inList)
            {
                return false;
            }
            else
            {
                oldList.Remove(door);
                _badgeDictionary[id] = oldList;
                return true;
            }
        }
    }
}
