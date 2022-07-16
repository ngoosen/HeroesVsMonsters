using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVSMonsters
{
    internal class Dragonnet : Monstre
    {
        public Dragonnet() : base()
        {
            BonusEnd = 1;
            DropOr = (new Dice(6)).Lance();
            DropCuir = (new Dice(4)).Lance();
        }
        public Dragonnet(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
        public override string GetRace()
        {
            return "Dragonnet";
        }
    }
}
