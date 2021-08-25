using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange6_ClassLibrary.CarTypes
{
    public class Electric : Car
    {
        public Electric() { }
        public Electric(string make, string model, int year, int id, double hoursToCharge, int milesOnCharge) :base(make, model, year, id)
        {
            HoursToCharge = hoursToCharge;
            MilesOnCharge = milesOnCharge;
        }
        public double HoursToCharge { get; set; }
        public int MilesOnCharge { get; set; }
    }
}
