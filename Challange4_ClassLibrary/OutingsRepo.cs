using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange4_ClassLibrary
{
    public class OutingsRepo
    {
        protected readonly List<Outings> _outingsCollection = new List<Outings>();

        //CRUD
        //C
        public bool AddToCollection(Outings outing)
        {
            int startingCount = _outingsCollection.Count();
            _outingsCollection.Add(outing);
            return _outingsCollection.Count() > startingCount;
        }

        //R
        public List<Outings> GetAllOutings()
        {
            return _outingsCollection;
        }

        public List<Outings> GetOutingByType(EventTypes type)
        {
            List<Outings> outings = GetAllOutings();
            List<Outings> returnOutings = new List<Outings>();
            foreach(Outings outing in outings)
            {
                if (outing.Event == type)
                {
                    returnOutings.Add(outing);
                }
            }
            return returnOutings;
        }

        //U
        //D
    }
}
