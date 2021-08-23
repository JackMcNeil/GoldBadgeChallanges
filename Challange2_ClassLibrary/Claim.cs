using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange2_ClassLibrary
{
    public enum ClaimTypes{ Car, Home, Theft};
    public class Claims
    {
        //Constructors
        public Claims() { }
        public Claims(int claimId, ClaimTypes claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        // Properties
        public int ClaimId { get; set; }
        public ClaimTypes ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan length = DateOfClaim - DateOfIncident;
                if (length.TotalDays >= 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

    }
}
