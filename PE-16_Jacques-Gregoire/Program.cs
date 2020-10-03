using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace PE_16_Jacques_Gregoire
{
    public interface ITakeOrder 
    {
        public void TakeOrder();
    }
    public interface IMood
    {
        public string Mood
        {
            get;
        }
    }

    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public HotDrink() 
        { 

        }

        public HotDrink(string brand)
        {
            
        }

        public virtual byte AddSugar (byte amount)
        {
           return amount;
        }

        public abstract void Steam();
        

        
    }

    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public CupOfCoffee(string brand): base(brand)
        {

        }


        public override void Steam()
        {
            
        }

        public void TakeOrder()
        {

        }
    }

    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public CupOfTea(bool customerIsWealthy)
        {

        }

        public override void Steam()
        {
            
        }

        public void TakeOrder()
        {

        }


    }

    public class CupOfCoca: HotDrink, ITakeOrder
    {

        public static int numCups;
        public bool marshmallows;
        private string source;


        public CupOfCoca(): this(false)
        {
        
        }
        
        public CupOfCoca(bool marshmallows):base("Expensive Organic Brand")
        {
        
        }
        public string Source
        {
            set
            {
                Source = source;
            }
        }

        public override byte AddSugar(byte amount)
        {
            return amount;
        }
        public override void Steam()
        {

        }

        public void TakeOrder()
        {

        }

    }

    public class Customer: IMood
    {
        public string name;
        public string creditCardNumber;
        public string Mood
        {
            get;
        }


       
    }

    public class Waiter: IMood
    {

        public string name;
        public void ServeCustomer(HotDrink cup)
        {

        }

        public string Mood
        {
            get;
        }
    }
    
}
