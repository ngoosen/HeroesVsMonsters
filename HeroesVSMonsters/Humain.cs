using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVSMonsters
{
    internal class Humain : Heros
    {
        public Humain() : base()
        {
            BonusEnd = 1;
            BonusFor = 1;
        }
        public Humain(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
    }
}
