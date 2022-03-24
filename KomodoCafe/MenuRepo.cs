using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuRepo
    {
        private List<OrderMenu> menuItems = new List<OrderMenu>();

        public void AddMenuItem(OrderMenu menuItem)
        {
            menuItems.Add(menuItem);
        }

        public List<OrderMenu> GetMenuItems()
        {
            return menuItems;
        }

        public bool RemoveMenuItem(int number)
        {
            OrderMenu item = GetMenuItemByNumber(number);
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

        public OrderMenu GetMenuItemByNumber(int number)
        {
            foreach (OrderMenu item in menuItems)
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
