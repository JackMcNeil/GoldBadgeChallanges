using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange6_ClassLibrary
{
    public class CarsRepository
    {
        private readonly List<Car> _carDirectory = new List<Car>();

        //C
        public bool AddCarToDirectory(Car car)
        {
            int startCount = _carDirectory.Count();
            _carDirectory.Add(car);
            return _carDirectory.Count() > startCount;
        }

        //R
        public List<Car> GetAllCars()
        {
            return _carDirectory;
        }

        public Car GetCarById(int id)
        {
            List<Car> allCars = GetAllCars();
            foreach(Car cr in allCars)
            {
                if (cr.Id == id)
                {
                    return cr;
                }
            }
            Console.WriteLine("No car with that Id found");
            return null;
        }

        //U
        /*
        public bool UpdateACar(Car newCar, int id)
        {
            Car carToUpdate = GetCarById(id);
            if (carToUpdate != null)
            {
                carToUpdate.Make = 
            }
        }*/

        //D

        public bool DeleteACar(Car car)
        {
            return _carDirectory.Remove(car);
        }
    }
}
