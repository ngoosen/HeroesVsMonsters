using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVSMonsters
{
    internal class Monstre : Personnage
    {
        // Props
        public int DropCuir { get; set; }
        public int DropOr { get; set; }

        // Ctor

        public Monstre()
        {
            Dice d = new Dice(6);

            int[] tab = new int[4];
            for (int i = 0; i < 4; i++)
            {
                tab[i] = d.Lance();
            }
            Array.Sort(tab);
            Endurance = tab[1] + tab[2] + tab[3]; // Endurance

            for (int i = 0; i < 4; i++)
            {
                tab[i] = d.Lance();
            }
            Array.Sort(tab);
            Force = tab[1] + tab[2] + tab[3]; // Force

            switch (Endurance + BonusEnd) // PV
            {
                case < 5:
                    PV = Endurance - 1;
                    break;
                case < 10:
                    PV = Endurance;
                    break;
                case < 15:
                    PV = Endurance + 1;
                    break;
                default:
                    PV = Endurance + 2;
                    break;
            }
        }

        // Méthodes
        public virtual string GetRace()
        {
            return "Monstre";
        }
    }
}
