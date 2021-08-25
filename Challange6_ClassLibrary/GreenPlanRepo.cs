using Challange6_ClassLibrary.CarTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange6_ClassLibrary
{
    public class GreenPlanRepo : CarsRepository
    {
        public Electric GetElectricById(int id)
        {
            foreach (Car item in _carDirectory)
            {
                if (item.GetType() == typeof(Electric) && item.Id == id)
                {
                    return (Electric) item;
                }
            }
            return null;
        }

        public Gas GetGasById(int id)
        {
            foreach (Car item in _carDirectory)
            {
                if (item.GetType() == typeof(Gas) && item.Id == id)
                {
                    return (Gas)item;
                }
            }
            return null;
        }

        public Hybrid GetHybridById(int id)
        {
            foreach (Car item in _carDirectory)
            {
                if (item.GetType() == typeof(Hybrid) && item.Id == id)
                {
                    return (Hybrid)item;
                }
            }
            return null;
        }

        public List<Electric> GetAllElectric()
        {
            return _carDirectory.Where(s => s is Electric).Cast<Electric>().ToList();
        }

        public List<Gas> GetAllGas()
        {
            return _carDirectory.Where(s => s is Gas).Cast<Gas>().ToList();
        }

        public List<Hybrid> GetAllHybrid()
        {
            return _carDirectory.Where(s => s is Hybrid).Cast<Hybrid>().ToList();
        }

        public bool UpdateElectric(Electric newCar)
        {
            Electric elley = GetElectricById(newCar.Id);
            if (elley != null)
            {
                elley.Make = newCar.Make;
                elley.Model = newCar.Model;
                elley.Year = newCar.Year;
                elley.MilesOnCharge = newCar.MilesOnCharge;
                elley.HoursToCharge = newCar.HoursToCharge;

                return true;
            }
            return false;
        }

        public bool UpdateGas(Gas newCar)
        {
            Gas gassy = GetGasById(newCar.Id);
            if (gassy != null)
            {
                gassy.Make = newCar.Make;
                gassy.Model = newCar.Model;
                gassy.Year = newCar.Year;
                gassy.MilesPerGallon = newCar.MilesPerGallon;
                gassy.TankSize = newCar.TankSize;

                return true;
            }
            return false;
        }

        public bool UpdateHybird(Hybrid newCar)
        {
            Hybrid hybrid = GetHybridById(newCar.Id);
            if (hybrid != null)
            {
                hybrid.Make = newCar.Make;
                hybrid.Model = newCar.Model;
                hybrid.Year = newCar.Year;
                hybrid.MilesPerGallon = newCar.MilesPerGallon;
                hybrid.HoursToCharge = newCar.HoursToCharge;

                return true;
            }
            return false;
        }
    }
}
