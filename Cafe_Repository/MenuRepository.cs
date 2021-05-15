using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    class MenuRepository
    {
        private readonly List<MenuItem> _menuItem = new List<MenuItem>();

        public bool AddItemToMenu(MenuItem newItem)
        {
            int startingCount = _menuItem.Count;
            _menuItem.Add(newItem);
            bool wasAdded = (_menuItem.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<MenuItem> GetMenuItems()
        {
            return _menuItem;
        }

        public MenuItem GetItemByName(string name)
        {
            foreach(MenuItem item in _menuItem)
            {
                if(item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public bool UpdateMenuItem(string oldItemInfo, MenuItem newItemInfo)
        {
            MenuItem oldItem = GetItemByName(oldItemInfo);
            if(oldItem != null)
            {
                oldItem.Number = newItemInfo.Number;
                oldItem.Name = newItemInfo.Name;
                oldItem.Description = newItemInfo.Description;
                oldItem.Ingredients = newItemInfo.Ingredients;
                oldItem.Price = newItemInfo.Price;
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool DeleteMenuItem(string nameToDelete)
        {
            MenuItem itemToDelete = GetItemByName(nameToDelete);
            if (itemToDelete == null)
            {
                return false;
            }
            else
            {
                _menuItem.Remove(itemToDelete);
                return true;
            }
        }
    }
}
