using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVSMonsters
{
    internal class Nain : Heros
    {
        public Nain() : base()
        {
            BonusEnd = 2;
        }
        public Nain(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
    }
}
