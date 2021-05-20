using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgesRepository
    {
        public Dictionary<int, List<string>> badgeDictionary = new Dictionary<int, List<string>>();

        public void SeedList()
        {
            badgeDictionary.Add(123, new List<string> { "A2", "A4" });
        }
        
        public bool CreateNewBadge(int newBadgeID, List<string> door)
        {
            int startingCount = badgeDictionary.Count;
            badgeDictionary.Add(newBadgeID, door);
            bool wasAdded = (badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Dictionary<int, List<string>> SeeAllBadges()
        {
            return badgeDictionary;
        }

        public Badges GetBadgeAccess(int id) //FIX TO dictionary type?
        {
            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                Console.WriteLine($"Key = {badge.Key}, Value = {badge.Value}");
            }
            return null;
        }

        public bool UpdateBadgeInfo(int id, Badges newBadgeInfo)
        {
            Badges oldBadgeInfo = GetBadgeAccess(id);
            if (oldBadgeInfo != null)
            {
                oldBadgeInfo.BadgeID = newBadgeInfo.BadgeID;
                oldBadgeInfo.DoorName = newBadgeInfo.DoorName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
