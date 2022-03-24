using Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace BadgeRepoTest
{
    [TestClass]
    public class BadgeRepoTests
    {
        [TestMethod]
        public void TestMethod1()
        {

            BadgeRepo repo = new BadgeRepo();
            List<string> doors = new List<string>() { "door1", "door2", "door3" };
            Badge badge = new Badge()
            {
                DoorNames = doors,
                ID = 1
            };
            repo.AddNewBadge(badge);
            Assert.IsNotNull(repo.GetBadges());
        }

        [TestMethod]
        public void UpdateBadge_ShouldUpdateBadge()
        {
            BadgeRepo repo = new BadgeRepo();
            List<string> doors = new List<string>() { "door1", "door2", "door3" };
            Badge badge = new Badge()
            {
                DoorNames = doors,
                ID = 1
            };

            List<string> doors2 = new List<string>() { "1door", "2door", "3door" };
            Badge badge2 = new Badge()
            {
                DoorNames = doors2,
                ID = 1
            };

            repo.AddNewBadge(badge);
            repo.UpdateExistingBadge(badge.ID, badge2);
            List<string> actual = repo.GetBadges()[badge2.ID];
            Assert.AreEqual(badge2.DoorNames, actual);
        }
    }
    }
}
