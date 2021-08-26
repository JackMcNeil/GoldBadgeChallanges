using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange7_ClassLibrary
{
    public class PartyRepo
    {
        protected private List<Party> _allParties = new List<Party>();

        //CRUD
        //C

        public bool AddParty(Party party)
        {
            int startingCount = _allParties.Count();
            _allParties.Add(party);
            return _allParties.Count() > startingCount;
        }

        //R

        public List<Party> GetAllParties()
        {
            return _allParties;
        }

        // No updating or deleting a party.
        //U 
        //D
    }
}
