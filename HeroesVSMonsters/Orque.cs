using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVSMonsters
{
    internal class Orque : Monstre
    {
        public Orque() : base()
        {
            BonusFor = 1;
            DropOr = (new Dice(6)).Lance();
        }
        public Orque(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
        public override string GetRace()
        {
            return "Orque";
        }
    }
}
