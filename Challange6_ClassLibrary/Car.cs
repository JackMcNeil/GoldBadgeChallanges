using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange6_ClassLibrary
{
     public abstract class Car
    {
        public Car() { }
        public Car(string make, string model, int year, int id)
        {
            Make = make;
            Model = model;
            Year = year;
            Id = id;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }

    }
}
