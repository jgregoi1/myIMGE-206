using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{

    public abstract class vehicle: PassengerCarrier
    {
        public virtual void loadPassenger()
        {

        }

       

    }

    public abstract class train : vehicle
    {

    }

    public abstract class car : vehicle
    {

    }

    public interface PassengerCarrier
    {
        void loadPassenger();
    }

    public interface HeavyLoadCarrier
    {
        
    }

    public class compact : car, PassengerCarrier
    {
        
    }

    public class SUV : car, PassengerCarrier
    {

    }

    public class pickup : car, HeavyLoadCarrier
    {

    }

    public class PassangerTrain : train, PassengerCarrier
    {

    }

    public class FreightTrain : train, HeavyLoadCarrier
    {

    }

    public class _424DoubleBogey : train, HeavyLoadCarrier
    {

    }

}
