using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class Badges
    {
        public int BadgeID { get; set; }

        public List<string> DoorName { get; set; } = new List<string>() { "A1", "A2", "A3", "A4", "A5", "A6", "B1", "B2", "B3", "B4", "B5", "C1", "C2" };

        public Badges() { }

        public Badges(int badgeID, List<string> doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }

    }
}
