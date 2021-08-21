using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange2_ClassLibrary
{
    public enum ClaimTypes{ Car, Home, Theft};
    public class Claim
    {
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
            }
        }

    }
}
