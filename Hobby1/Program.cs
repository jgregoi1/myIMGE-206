using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby1
{
    class Program
    {
        static void Main(string[] args)
        {
            EurpoeanMartialArts EMA = new EurpoeanMartialArts();
            Fencing fencer = new Fencing();

            MyMethod(EMA);
            MyMethod(fencer);
        }

        static void MyMethod(object obj)
        {
            IOffense offense = (IOffense)obj;
            offense.Slash();
            offense.Stab();
            IDeffense defense = (IDeffense)obj;
            defense.Block();
            defense.Counter();
            MeleeCombat melee = (MeleeCombat)obj;
            melee.Fight();
        }
    }

    public interface IOffense
    {
        public void Slash();
        public void Stab();
    }

    public interface IDeffense
    {
        public void Counter();
        public void Block();
    }

    public abstract class MeleeCombat
    {
        public abstract void Fight();
    }

    public class EurpoeanMartialArts: MeleeCombat, IOffense, IDeffense
    {
        public override void Fight()
        {

        }

        public void Counter()
        {

        }

        public void Block()
        {

        }

        public void Slash()
        {

        }

        public void Stab()
        {

        }
        public string WeaponType
        {
            get
            {
                return WeaponType;
            }
            set
            {
                WeaponType = value;
            }
        }

    }

    public class Fencing: MeleeCombat, IDeffense, IOffense
    {
        public override void Fight()
        {

        }

        public void Counter()
        {

        }

        public void Block()
        {

        }

        public void Slash()
        {

        }

        public void Stab()
        {

        }
        public virtual void Parry()
        {

        }
    }
    
}
