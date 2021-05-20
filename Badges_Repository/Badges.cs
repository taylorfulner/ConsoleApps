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

        public List<string> DoorName { get; set; } = new List<string>();

        public Badges() { }

        public Badges(int badgeID, List<string> doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }

    }
}
