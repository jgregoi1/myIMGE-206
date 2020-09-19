using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{

    public abstract class vehicle
    {
        public virtual void LoadPassenger()
        {

        }

        

    }

    public abstract class train : vehicle
    {

    }

    public abstract class car : vehicle
    {

    }

    public interface PassangerCarrier
    {
        void loadPassenger();
    }

    public interface HeavyLoadCarrier
    {

    }

    public class compact : car, PassangerCarrier
    {

    }

    public class SUV : car, PassangerCarrier
    {

    }

    public class pickup : car, HeavyLoadCarrier
    {

    }

    public class PassangerTrain : train, PassangerCarrier
    {

    }

    public class FreightTrain : train, HeavyLoadCarrier
    {

    }

    public class _424DoubleBogey : train, HeavyLoadCarrier
    {

    }

}
