using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsRepo_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClaimsRepo repo = new ClaimsRepo();
            Claim claim = new Claim()
            {
                Amount = 2.50m,
                Description = "desc",
                ClaimID = 1,
                Type = Claim.ClaimType.Car,
                DateOfClaim = DateTime.Now,
                DateOfIncident = DateTime.Today,
                IsValid = true
            };
            repo.AddNewClaim(claim);
            Assert.IsNotNull(repo.GetClaims());
        }
    }
    
}
