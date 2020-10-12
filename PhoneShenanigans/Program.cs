using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShenanigans
{
    public interface PhoneInterface
    {
        public void Answer();
        public void MakeCall();
        public void HangUp();

    }
    class Program
    {
        

        static void Main(string[] args)
        {
            Tardis myTardis = new Tardis();
            PhoneBooth myBooth = new PhoneBooth();
            UsePhone(myBooth);
            UsePhone(myTardis);

        }

        static void UsePhone(object obj)
        {
            PhoneInterface MyInterface = (PhoneInterface)obj;

            MyInterface.MakeCall();
            MyInterface.HangUp();

            
            

            if (obj.Equals(typeof(PhoneBooth)))
            {
                PhoneBooth myBooth = (PhoneBooth)obj;
                myBooth.openDoor();
            }
            if (obj.Equals(typeof(Tardis)))
            {
                Tardis mytardis = (Tardis)obj;
                mytardis.TimeTravel();
            }
            
        }
    }

    public abstract class Phone
    {
        private string phoneNumber;
        public string adress;

        public string PhoneNumber
        {
            get
            {
                return PhoneNumber;
            }
            set
            {
                PhoneNumber = value;
            }
        }

        public abstract void Connect();
        public abstract void Disconnect();
    }

    public class RotaryPhone: Phone, PhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {

        }
    }

    public class PushButtonPhone: Phone, PhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {

        }
    }

    public class PhoneBooth: PushButtonPhone
    {
        private bool superMan;
        public bool phoneBook;
        public double costPerCall;
        
        public void openDoor()
        {

        }

        public void closeDoor()
        {

        }
    }

    public class Tardis: RotaryPhone
    {
        private bool sonicScrewDriver;

        private byte whichDrWho;

        private string femaleSideKick;

        public double exteriorSurfaceArea;

        public double interiorVolume;
        public byte WhichDrWho
        {
            get
            {
                return WhichDrWho;
            }      
        }

        public string FemaleSideKick
        {
            get
            {
                return FemaleSideKick;
            }
        }

        public void TimeTravel()
        {

        }

        public static bool operator <(Tardis t1, Tardis t2 )
        {
            if (t2.whichDrWho == 10)
            {
                return true;
            }
            else
            {
                return (t1.whichDrWho < t2.whichDrWho);
            }
        }

        public static bool operator >(Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == 10)
            {
                return true;
            }
            else
            {
                return (t1.whichDrWho > t2.whichDrWho);
            }
        }

        public static bool operator <=(Tardis t1, Tardis t2)
        {
            if (t2.whichDrWho == 10 && t2.whichDrWho != t1.whichDrWho)
            {
                return true;
            }
            else
            {
                return (t1.whichDrWho <= t2.whichDrWho);
            }
        }

        public static bool operator >=(Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == 10 && t1.whichDrWho != t2.whichDrWho)
            {
                return true;
            }
            return (t1.whichDrWho >= t2.whichDrWho);
        }

        public static bool operator ==(Tardis t1, Tardis t2)
        {
            return (t1.whichDrWho == t2.whichDrWho);
        }

        public static bool operator !=(Tardis t1, Tardis t2)
        {
            return (t1.whichDrWho != t2.whichDrWho);
        }
    }


}
