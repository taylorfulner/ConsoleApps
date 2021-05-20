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
            _badgeDictionary.Add(124, new List<string> { "B2", "C2" });
        }

        public bool CreateNewBadge(int newBadgeID, List<string> door)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(newBadgeID, door);
            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Dictionary<int, List<string>> GetBadgeAccess()
        {
            return _badgeDictionary;
        }


        public Badges SeeBadgeByID(int id)
        {
            if (_badgeDictionary.ContainsKey(id))
            {
                Badges newBadge = new Badges(id, _badgeDictionary[id]);
                return newBadge;
            }
            return null;
        }


        public bool AddDoor(int id, string newBadgeDoor)
        {
            Badges oldDoor = SeeBadgeByID(id);
            if (oldDoor != null)
            {
                _badgeDictionary[id].Add(newBadgeDoor);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDoor(int id, string newBadgeDoor)
        {
            Badges oldDoor = SeeBadgeByID(id);
            if (oldDoor != null)
            {
                _badgeDictionary[id].Remove(newBadgeDoor);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
