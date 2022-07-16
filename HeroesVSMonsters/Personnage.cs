using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVSMonsters
{
    internal class Personnage
    {
        // Props
        public int Endurance { get; protected set; }
        public int Force { get; protected set; }
        public int BonusEnd { get; set; }
        public int BonusFor { get; set; }
        public int PV { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        // Méthodes
        public int Frappe()
        {
            switch (Force + BonusFor) // PV
            {
                case < 5:
                    return (new Dice(4).Lance()) - 1;
                case < 10:
                    return new Dice(4).Lance();
                case < 15:
                    return (new Dice(4).Lance()) + 1;
                default:
                    return (new Dice(4).Lance()) + 2;
            }
        }
    }
}
