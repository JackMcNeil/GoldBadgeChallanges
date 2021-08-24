using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange4_ClassLibrary
{
    public enum EventTypes { Golf, Bowling, AmusementPark, Concert}
    public class Outings
    {
        public Outings() { }
        public Outings(EventTypes eventType, int attendees, DateTime date, double totalCost)
        {
            Event = eventType;
            Attendees = attendees;
            Date = date;
            TotalCost = totalCost;
        }

        public EventTypes Event { get; set; }
        public int Attendees { get; set; }
        public DateTime Date { get; set; }
        public double TotalCost { get; set; }
        public double TotalCostPerPerson
        {
            get
            {
                return Math.Round(TotalCost / Attendees , 2);
            }
        }
    }
}
