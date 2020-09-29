using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PE_14
{
    public interface ImyInterface
    {
        void myMethod();
    }

    public class myClass : ImyInterface
    {
        public void myMethod()
        {
            Console.WriteLine("this came from myMethod");
        }

    }

    public class myOtherClassYouKnowTheOneThatsBetterThanMyClass : ImyInterface
    {
        public void myMethod()
        {
            Console.WriteLine("this came from the better myMethod");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            myClass myClass2 = new myClass();
            myOtherClassYouKnowTheOneThatsBetterThanMyClass myBetterClass2 = new myOtherClassYouKnowTheOneThatsBetterThanMyClass();

            //ImyInterface myInter = myBetterClass2;

            //ImyInterface myOtherInter = myClass2;

            MyMethod(myClass2);

            MyMethod(myBetterClass2);           
            
        }


        public static void MyMethod(object myObject) 
        {
            ImyInterface iMyInterface = (ImyInterface)myObject;
            iMyInterface.myMethod();
        }

        
    }


    

}

