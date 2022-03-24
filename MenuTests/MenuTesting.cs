using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MenuTests
{
    [TestClass]
    public class MenuTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            MenuRepo repo = new MenuRepo();
            List<string> ing = new List<string>() { "ing1", "ing2", "ing3" };
            OrderMenu menu = new OrderMenu()
            {
                ItemNumber = 1,
                MealName = "Name",
                Ingredients = ing,
                Description = "desc",
                Price = 2.50m
            };
            repo.AddMenuItem(menu);
            Assert.IsNotNull(repo.GetMenuItems());
        }

        [TestMethod]
        public void UpdateMenuItem_ShouldUpdateItem()
        {
            MenuRepo repo = new MenuRepo();
            List<string> ing = new List<string>() { "ing1", "ing2", "ing3" };
            Menu menu = new Menu()
            {
                ItemNumber = 1,
                MealName = "Name",
                Ingredients = ing,
                Description = "desc",
                Price = 2.50m
            };
            List<string> ing2 = new List<string>() { "1ing", "2ing", "3ing" };
            Menu menu2 = new Menu()
            {
                ItemNumber = 2,
                MealName = "Name2",
                Ingredients = ing2,
                Description = "desc2",
                Price = 2.75m
            };
            repo.AddMenuItem(menu);
            repo.UpdateExistingMenuItem(menu.ItemNumber, menu2);
            Menu actual = repo.GetMenuItems()[0];
            Assert.AreEqual(menu2, actual);
        }

        [TestMethod]
        public void RemoveMenuItem_ShouldHaveZeroItems()
        {
            MenuRepo repo = new MenuRepo();
            List<string> ing = new List<string>() { "ing1", "ing2", "ing3" };
            Menu menu = new Menu()
            {
                ItemNumber = 1,
                MealName = "Name",
                Ingredients = ing,
                Description = "desc",
                Price = 2.50m
            };
            repo.AddMenuItem(menu);
            repo.RemoveMenuItem(menu.ItemNumber);
            Assert.IsTrue(repo.GetMenuItems().Count == 0);
        }
    }
    }
}
