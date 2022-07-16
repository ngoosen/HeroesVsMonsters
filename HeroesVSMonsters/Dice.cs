using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVSMonsters
{
    internal class Dice
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        //Ctor

        public Dice(int d)
        {
            Minimum = 1;
            Maximum = d;
        }

        //Méthodes
        public int Lance()
        {
            return (new Random()).Next(Minimum, Maximum+1);
        }
    }
}
