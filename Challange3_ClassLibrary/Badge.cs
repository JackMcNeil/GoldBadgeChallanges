using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange3_ClassLibrary
{
    public class Badge
    {
        private int _badgeId;
        public Badge() { }
        public Badge(int badgeId, List<string> doorNames)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;
        }

        public int BadgeId { get => _badgeId; set => _badgeId = value; }
        public List<string> DoorNames { get; set; }
    }
}
