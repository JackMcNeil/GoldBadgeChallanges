using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange6_ClassLibrary.CarTypes
{
    public class Hybrid : Car
    {
        public Hybrid() { }
        public Hybrid(string make, string model, int year, int id, double milesPerGallon, int hoursToCharge) : base(make, model, year, id) 
        {
            HoursToCharge = hoursToCharge;
            MilesPerGallon = milesPerGallon;
        }
        public int HoursToCharge { get; set; }
        public double MilesPerGallon { get; set; }
    }
}
