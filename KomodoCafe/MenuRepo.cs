using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuRepo
    {
        private List<Menu> menuItems = new List<Menu>();

        public void AddMenuItem(Menu menuItem)
        {
            menuItems.Add(menuItem);
        }

        public List<Menu> GetMenuItems()
        {
            return menuItems;
        }

        public bool RemoveMenuItem(int number)
        {
            Menu item = GetMenuItemByNumber(number);
            if (item != null)
            {
                int initialCount = menuItems.Count;
                menuItems.Remove(item);
                if (initialCount > menuItems.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Menu GetMenuItemByNumber(int number)
        {
            foreach (Menu item in menuItems)
            {
                if (item.ItemNumber == number)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
