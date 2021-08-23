using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange3_ClassLibrary
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeId, List<string> doorNames)
        {
            BadgeID = badgeId;
            DoorNames = doorNames;
        }

        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
    }
}
