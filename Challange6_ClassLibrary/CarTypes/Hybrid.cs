using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange6_ClassLibrary.CarTypes
{
    public class Hybrid : Gas 
    {
        public Hybrid(string make, string model, int year, int id, double milesPerGallon, int tankSize, int hoursToCharge) : base(make, model, year, id, milesPerGallon, tankSize) 
        {
            HoursToCharge = hoursToCharge;
        }
        public int HoursToCharge { get; set; }
    }
}
