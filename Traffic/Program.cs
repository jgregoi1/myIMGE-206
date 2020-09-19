using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle;

namespace Traffic
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
        public static void AddPassenger(PassengerCarrier thing)
        {
            //PassengerCarrier.loadPassenger();
            PassengerCarrier carrier = (PassengerCarrier)thing;

            carrier.loadPassenger();

            Console.WriteLine(thing.ToString());
        }
    }
}
