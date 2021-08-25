using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange6_ClassLibrary.CarTypes
{
    public class Gas : Car
    {
        public Gas() { }
        public Gas(string make, string model, int year, int id, double milesPerGallon, int tankSize) :base(make, model, year, id)
        {
            MilesPerGallon = milesPerGallon;
            TankSize = tankSize;
        }

        public double MilesPerGallon { get; set; }
        public int TankSize { get; set; }
    }
}
