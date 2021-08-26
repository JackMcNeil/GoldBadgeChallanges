using Challange3_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange3_ConsoleApp.UI
{
    public class ProgramUI
    {
        private readonly BadgeRepo _repo = new BadgeRepo();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            List<string> badge1List = new List<string>() { "A5", "A7", "B5" };
            List<string> badge2List = new List<string>() { "A3"};
            Badge badge1 = new Badge(123, badge1List);
            Badge badge2 = new Badge(15045, badge2List);

            _repo.AddNewBadge(badge1);
            _repo.AddNewBadge(badge2);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu:\n  Hello Secuirty Admin, What would you like to do?\n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "1":
                    case "add":
                    case "add a badge":
                        AddNewBadge();
                        break;
                    case "2":
                    case "edit":
                    case "edit a badge":
                        UpdateABadge();
                        break;
                    case "3":
                    case "list":
                    case "list all badges":
                        ListAllBadges();
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

        public void AddNewBadge()
        {
            Console.Clear();
            Badge badgeToAdd = new Badge();
            int id = 0;
            List<string> listOfRooms = new List<string>();
            bool validId = false;
            while (!validId)
            {
                Console.Write("What is the number on the badge:  ");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    validId = true;
                }
                catch
                {
                    Console.WriteLine("Not a valid id number");
                    ContinueMessage();
                }
            }
            bool addingRooms = false;
            do
            {
                string room = null;
                bool roomWorks = false;
                while (!roomWorks)
                {
                    Console.Write("List a door that it needs access to: ");
                    room = Console.ReadLine();
                    if (room.Length > 2)
                    {
                        Console.WriteLine("Not a valid room.");
                        ContinueMessage();
                    }
                    else if(room.Length < 2)
                    {
                        Console.WriteLine("Not a valid room.");
                        ContinueMessage();
                    }
                    else
                    {
                        roomWorks = true;
                    }
                }
                listOfRooms.Add(room);

                //Keep going loop
                bool validAns = false;
                while (!validAns)
                {
                    Console.Write("Any other doors(y/n)? ");
                    string ans = Console.ReadLine().ToLower();
                    if(ans == "y" || ans == "yes")
                    {
                        addingRooms = true;
                        validAns = true;
                    }
                    else if(ans == "n" || ans == "no")
                    {
                        addingRooms = false;
                        validAns = true;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid input");
                        ContinueMessage(); 
                    }
                }
            } while (addingRooms);
            badgeToAdd.BadgeId = id;
            badgeToAdd.DoorNames = listOfRooms;
            Dictionary<int, List<string>> badges = _repo.GetAllBadges();
            if (badges.ContainsKey(id))
            {
                Console.WriteLine("There is already a badge with that Id");
                ContinueMessage();
            }
            else
            {
                _repo.AddNewBadge(badgeToAdd);
            }
        }

        public void UpdateABadge()
        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _repo.GetAllBadges();
            Console.Write("What is the badge number to update? ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{id} has access to doors {string.Join(" & ",badges[id])}");
            bool keepMakingChanges = false;
            while (!keepMakingChanges)
            {
                bool validOption = false;
                while (!validOption)
                {
                    Console.WriteLine("What would you like to do?\n" +
                        "1. Remove a door\n" +
                        "2. Add a door");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "1" || answer == "remove a door")
                    {
                        Console.Write("Which door would you like to remove? ");
                        string door = Console.ReadLine();
                        bool delete = _repo.RemoveExisitngDoor(id, door);
                        if (delete)
                        {
                            Console.WriteLine("Door Removed");
                        }
                        else
                        {
                            Console.WriteLine($"Door {door} does not exist for this badge");
                        }
                        validOption = true;
                    }
                    else if (answer == "2" || answer == "add a door")
                    {
                        Console.Write("Which door would you like to add? ");
                        string door = Console.ReadLine();
                        bool delete = _repo.UpdateExistingBadge(id, door);
                        if (delete)
                        {
                            Console.WriteLine("Door added");
                        }
                        else
                        {
                            Console.WriteLine($"Door {door} already stored for this badge");
                        }
                        validOption = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        ContinueMessage();
                    }
                }
                Console.Write("Do you want to keep making changes to this door (y/n)? ");
                Console.Clear();
                string keepGoing = Console.ReadLine();
                if(keepGoing == "n" || keepGoing == "no")
                {
                    keepMakingChanges = true;
                }
            }
            Console.WriteLine($"{id} has access to doors {string.Join(" & ", badges[id])}");
            ContinueMessage();
        }

        public void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _repo.GetAllBadges();
            Console.WriteLine("Key\n" +
                "Badge #          Door Access");
            foreach (int badge in badges.Keys)
            {
                Console.WriteLine($"{badge, -17}{string.Join(", ",badges[badge])}");
            }
            ContinueMessage();
        }

        public void ContinueMessage()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
