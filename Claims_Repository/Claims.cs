using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public enum ClaimType { car, home, theft }

    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                TimeSpan dateSinceIncident = DateOfClaim - DateOfIncident;
                int daysSinceIncident = Convert.ToInt32(dateSinceIncident.TotalDays);
                if (daysSinceIncident <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
