using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public class ClaimsRepository
    {
        private readonly Queue<Claims> _claimInfo = new Queue<Claims>();

        public bool CreateClaim(Claims newClaim)
        {
            int startingCount = _claimInfo.Count;
            _claimInfo.Enqueue(newClaim);
            bool wasAdded = (_claimInfo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Queue<Claims> GetClaims()
        {
            return _claimInfo;
        }

        public Queue<Claims> GetClaimFromQueue()
        {
            return _claimInfo;
        }

        public bool UpdateClaim(Claims oldInfo, Claims newInfo)
        {
            Claims oldClaim = _claimInfo.Peek();
            if (oldClaim != null)
            {
                oldInfo.ClaimID = newInfo.ClaimID;
                oldInfo.ClaimType = newInfo.ClaimType;
                oldInfo.Description = newInfo.Description;
                oldInfo.ClaimAmount = newInfo.ClaimAmount;
                oldInfo.DateOfIncident = newInfo.DateOfIncident;
                oldInfo.DateOfClaim = newInfo.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Queue<Claims> DeleteClaimFromQueue()
        {
            return _claimInfo;
        }
    }
}
