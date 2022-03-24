using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimsProject
{
    public class ClaimsRepo
    {
        private Queue<Claim> claimQueue = new Queue<Claim>();


        public void AddNewClaim(Claim claim)
        {
            claimQueue.Enqueue(claim);
        }


        public Queue<Claim> GetClaims()
        {
            return claimQueue;
        }
    }
}
