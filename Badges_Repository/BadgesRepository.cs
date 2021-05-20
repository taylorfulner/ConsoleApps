using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgesRepository
    {
        public Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        public List<string> _doorNames = new List<string> { "A1", "A2", "A3", "A4", "A5", "A6", "B1", "B2", "B3", "B4", "B5", "C1", "C2" };

        public void SeedList()
        {
            _badgeDictionary.Add(123, new List<string> { "A2", "A4" });
            _badgeDictionary.Add(124, new List<string> { "B2", "C4" });
        }

        public bool CreateNewBadge(int newBadgeID, List<string> door)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(newBadgeID, door);
            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Badges SeeBadgeByID(int id)
        {
            foreach (KeyValuePair<int, List<string>> badge in _badgeDictionary)
            {
                Console.WriteLine($"Key = {badge.Key}, Value = {badge.Value}");
            }
            return null;
        }

        public Dictionary<int, List<string>> GetBadgeAccess() //FIX TO dictionary type?
        {
            return _badgeDictionary;
        }

        public bool UpdateBadgeInfo(int id, Badges newBadgeInfo)
        {
            Badges oldBadgeInfo = SeeBadgeByID(id);
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

        public bool DeleteBadge(int idToDelete)
        {
            Badges id = SeeBadgeByID(idToDelete);
            if (id == null)
            {
                return false;
            }
            else
            {
                _badgeDictionary.Remove(idToDelete);
                return true;
            }
        }
    }
}
