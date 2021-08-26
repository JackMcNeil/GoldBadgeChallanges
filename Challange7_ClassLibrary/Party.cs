using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange7_ClassLibrary
{
    public class Party
    {
        public Party() { }
        public Party(int burgerTickets, double iceCreamTickets, double burgerBooth, double iceCreamBooth)
        {
            BurgerTickets = burgerTickets;
            IceCreamBooth = iceCreamTickets;
            BurgerBooth = burgerBooth;
            IceCreamBooth = iceCreamBooth;
        }
        public int TotalTickets { get { return BurgerTickets + IceCreamTickets; } }
        public double TotalCost { get { return BurgerBooth + IceCreamBooth; } }
        public double BurgerBooth { get; set; }
        public double IceCreamBooth { get; set; }
        public int BurgerTickets { get; set; }
        public int IceCreamTickets { get; set; }
    }
}
