using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimsProject
{
    public class Claim
    {
        public enum ClaimType
        {
            Car = 1,
            Theft = 2,
            Home = 3
        }
        public int ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim()
        {

        }

        public Claim(int id, ClaimType type, string desc, decimal amount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = id;
            Type = type;
            Description = desc;
            Amount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
