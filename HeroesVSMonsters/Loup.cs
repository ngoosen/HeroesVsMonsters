using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVSMonsters
{
    internal class Loup : Monstre
    {
        public Loup() : base()
        {
            DropCuir = (new Dice(4)).Lance();
        }
        public Loup(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
        public override string GetRace()
        {
            return "Loup";
        }
    }
}
