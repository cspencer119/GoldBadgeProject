using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class OrderMenu
    {
        public int ItemNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        public OrderMenu()
        {
            Ingredients = new List<string>();
        }

        public OrderMenu(int num, string name, string desc, List<string> ingredients, decimal price)
        {
            ItemNumber = num;
            MealName = name;
            Description = desc;
            Ingredients = ingredients;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderMenu)
            {
                var that = obj as OrderMenu;
                return this.ItemNumber == that.ItemNumber
                    && this.MealName == that.MealName
                    && this.Description == that.Description
                    && this.Ingredients == that.Ingredients
                    && this.Price == that.Price;
            }
            return false;
        }
    }
}
