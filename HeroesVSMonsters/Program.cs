using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesVSMonsters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dragonnet dragon1 = new Dragonnet(12, 8); // Création des monstres + définition de leurs positions
            Dragonnet dragon2 = new Dragonnet(7, 14);

            Orque orc1 = new Orque(5, 9);
            Orque orc2 = new Orque(1, 11);
            Orque orc3 = new Orque(10, 3);

            Loup loup1 = new Loup(6, 6);
            Loup loup2 = new Loup(13, 2);
            Loup loup3 = new Loup(3, 7);
            Loup loup4 = new Loup(9, 11);
            Loup loup5 = new Loup(2, 3);

            List<Monstre> listeMonstres = new(); // Création d'une liste de monstres

            listeMonstres.Add(dragon1);
            listeMonstres.Add(dragon2);
            listeMonstres.Add(orc1);
            listeMonstres.Add(orc2);
            listeMonstres.Add(orc3);
            listeMonstres.Add(loup1);
            listeMonstres.Add(loup2);
            listeMonstres.Add(loup3);
            listeMonstres.Add(loup4);
            listeMonstres.Add(loup5);

            string[,] zone = new string[15, 15]; // Création de la zone de forêt

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    zone[i, j] = " ||. ";
                }
            }

            Console.WriteLine("Bienvenue dans la forêt de Shorewood!"); // Création du héros
            Console.WriteLine("Les monstres ont pris le contrôle de la forêt! Il nous faut un héros pour reprendre le territoire. Acceptez-vous la mission?");
            string rep = Console.ReadLine();
            if (rep == "non" || rep == "Non") Console.WriteLine("En fait c'était un question réthorique pour l'immersion dans le jeu, je vais faire comme si j'avais rien entendu.");
            Console.WriteLine("Super! Quel héros souhaitez-vous incarner?");
            Console.WriteLine("Tapez 1 pour jouer un humain (+1 en Force et +1 en Endurance");
            Console.WriteLine("Tapez 2 pour jouer un nain (+2 en Endurance)");

            int quelHero;
            string choixHero = Console.ReadLine();
            while(!int.TryParse(choixHero, out quelHero) || (quelHero != 1 && quelHero != 2))
            {
                Console.WriteLine("Veuillez entrer un chiffre valide!");
                Console.WriteLine("Tapez 1 pour jouer un humain (+1 en Force et +1 en Endurance");
                Console.WriteLine("Tapez 2 pour jouer un nain (+2 en Endurance");
            }

            Heros hero = new Heros();
            if(quelHero == 1)
            {
                hero = new Humain();
            }
            else
            {
                hero = new Nain();
            }

            hero.X = (new Random()).Next(0, 15); // Position de départ du héros
            hero.Y = (new Random()).Next(0, 15);

            foreach(Monstre m in listeMonstres)
            {
                if(hero.X == m.X && hero.Y == m.Y)
                {
                    hero.X = (new Random()).Next(0, 15);
                    hero.Y = (new Random()).Next(0, 15);
                }
                if((hero.X == m.X - 1 && hero.Y == m.Y) || (hero.X == m.X + 1 && hero.Y == m.Y) || (hero.Y == m.Y - 1 && hero.X == m.X) || (hero.Y == m.Y + 1 && hero.X == m.X))
                {
                    hero.X = (new Random()).Next(0, 15);
                    hero.Y = (new Random()).Next(0, 15);
                }
            }

            zone[hero.X, hero.Y] = "  H  ";

            Console.WriteLine("Prêt? C'est parti!\n\n");
            Console.WriteLine("-------------------- Forêt de Shorewood --------------------\n"); // Création de la forêt dans la console

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (zone[i, j] == " ||. ") Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(zone[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("Les monstres sont cachés! Il faut les dénicher et s'en débarasser!\n");

            ConsoleKeyInfo direction;
            int blessuresHeros = 0;
            int nbTours = 0;
            int nbPotions = 1;
            List<Monstre> morts = new();
            bool bouclier = false;
            int degatsBouclier = 5;

            while (blessuresHeros < hero.PV && listeMonstres.Count() > 0)     /////// Jeu
            {
                Console.WriteLine($"---------- Tour {++nbTours} ----------");

                Console.WriteLine("Explorez la forêt à l'aide des touches:");
                Console.WriteLine("Z pour aller vers le haut");
                Console.WriteLine("Q pour aller à gauche");
                Console.WriteLine("D pour aller à droite");
                Console.WriteLine("S pour aller vers le bas");

                direction = Console.ReadKey();

                while(direction.Key != ConsoleKey.Z && direction.Key != ConsoleKey.Q && direction.Key != ConsoleKey.S && direction.Key != ConsoleKey.D)
                {
                    Console.WriteLine("Lettre invalide!\n");
                    Console.WriteLine("Explorez la forêt à l'aide des touches:");
                    Console.WriteLine("Z pour aller vers le haut");
                    Console.WriteLine("Q pour aller à gauche");
                    Console.WriteLine("D pour aller à droite");
                    Console.WriteLine("S pour aller vers le bas");
                    direction = Console.ReadKey();
                }

                zone[hero.X, hero.Y] = "  *  ";
                foreach(Monstre m in morts)
                {
                    zone[m.X, m.Y] = "  X  ";
                }

                try
                {
                    switch (direction.Key)
                    {
                        case ConsoleKey.Z:
                            if (hero.X - 1 < 0) throw new Exception();
                            else hero.X -= 1;
                            break;
                        case ConsoleKey.Q:
                            if (hero.Y - 1 < 0) throw new Exception();
                            else hero.Y -= 1;
                            break;
                        case ConsoleKey.D:
                            if (hero.Y + 1 > 14) throw new Exception();
                            else hero.Y += 1;
                            break;
                        case ConsoleKey.S:
                            if (hero.X + 1 > 14) throw new Exception();
                            else hero.X += 1;
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("\nAttention, vous tentez de sortir de la forêt mais tous les monstres ne sont pas morts!\n");
                }

                zone[hero.X, hero.Y] = "  H  ";

                foreach(Monstre m in listeMonstres)
                {
                    if ((hero.X == m.X - 1 && hero.Y == m.Y) || (hero.X == m.X + 1 && hero.Y == m.Y) || (hero.Y == m.Y - 1 && hero.X == m.X) || (hero.Y == m.Y + 1 && hero.X == m.X))
                    {
                        switch (m.GetRace())
                        {
                            case "Loup":
                                zone[m.X, m.Y] = "  L  ";
                                break;
                            case "Orque":
                                zone[m.X, m.Y] = "  O  ";
                                break;
                            default:
                                zone[m.X, m.Y] = "  D  ";
                                break;
                        }
                    }

                }
                Console.Clear();
                Console.WriteLine("-------------------- Forêt de Shorewood --------------------\n");

                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (zone[i, j] == " ||. ") Console.ForegroundColor = ConsoleColor.DarkGreen;
                        if (zone[i, j] == "  X  ") Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(zone[i, j]);
                        Console.ResetColor();
                    }
                    Console.WriteLine("\n");
                }

                foreach(Monstre m in listeMonstres)
                {
                    if ((hero.X == m.X - 1 && hero.Y == m.Y) || (hero.X == m.X + 1 && hero.Y == m.Y) || (hero.X == m.X && hero.Y == m.Y - 1) || (hero.X == m.X && hero.Y == m.Y + 1))
                    {
                        Console.WriteLine($"Vous avez trouvé un {m.GetRace()}! Le combat va commencer!");
                        Console.WriteLine($"Vous pouvez utiliser une potion avec P pour vous guérir de 3 blessures. Vous possédez {nbPotions} potions.");
                        Console.WriteLine($"Vos PV: {hero.PV} PV\n");
                        ConsoleKeyInfo potionOuPas = Console.ReadKey();

                        while(blessuresHeros < hero.PV && m.PV > 0)
                        {
                            Console.WriteLine("Vous attaquez!");
                            int degats = hero.Frappe();

                            if(degats > 0)
                            {
                                m.PV -= degats;
                                Console.WriteLine($"Vous faites {degats} dégâts!\n");
                            }
                            else Console.WriteLine("Le monstre esquive le coup!\n");

                            potionOuPas = Console.ReadKey();
                            if (potionOuPas.Key == ConsoleKey.P)
                            {
                                if(nbPotions < 1)
                                {
                                    Console.WriteLine("Vous n'avez pas de potion!\n");
                                }
                                else
                                {
                                    blessuresHeros -= 3;
                                    if (blessuresHeros < 0) blessuresHeros = 0;
                                    nbPotions--;
                                    Console.WriteLine("Vous buvez une potion et récupérez 3 PV.\n");
                                }
                            }

                            if(m.PV > 0)
                            {
                                degats = m.Frappe();
                                Console.WriteLine("Le monstre vous attaque!");

                                if(degats > 0)
                                {
                                    if (bouclier)
                                    {
                                        degatsBouclier -= degats;

                                        if(degatsBouclier <= 0)
                                        {
                                            if(degats >= degatsBouclier)
                                            {
                                                Console.WriteLine($"Votre bouclier a absorbé {degatsBouclier + degats} dégâts!");
                                                degats -= degatsBouclier + degats;
                                            }
                                            Console.WriteLine("Vous bouclier s'est cassé!\n");
                                            bouclier = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Votre bouclier a absorbé {degats} dégâts!");
                                            degats = 0;
                                        }
                                    }

                                    blessuresHeros += degats;
                                    Console.WriteLine($"Le monstre vous fait {degats} dégâts!\n");
                                }
                                else
                                {
                                    Console.WriteLine("Vous esquivez le coup du monstre!\n");
                                }


                                potionOuPas = Console.ReadKey();
                                if (potionOuPas.Key == ConsoleKey.P)
                                {
                                    if (nbPotions < 1)
                                    {
                                        Console.WriteLine("Vous n'avez pas de potion!\n");
                                    }
                                    else
                                    {
                                        blessuresHeros -= 3;
                                        if (blessuresHeros < 0) blessuresHeros = 0;
                                        nbPotions--;
                                        Console.WriteLine("Vous buvez une potion et récupérez 3 PV.\n");
                                    }
                                }
                            }
                        }

                        if(blessuresHeros >= hero.PV)
                        {
                            Console.WriteLine("Le monstre a gagné! Vous êtes mort!");
                        }
                        else if (m.PV <= 0)
                        {
                            Console.WriteLine("Le monstre est mort! Vous avez gagné le combat!\n");
                            Console.ReadLine();
                            morts.Add(m);
                            zone[m.X, m.Y] = "  X  ";

                            hero.LootCuir += m.DropCuir;
                            hero.LootOr += m.DropOr;

                            if (m.DropCuir > 0) Console.WriteLine("Vous dépecez le monstre de son cuir!");
                            if (m.DropOr > 0) Console.WriteLine("Vous récoltez l'or du monstre!");
                            Console.WriteLine($"Vous avez {hero.LootCuir} morceaux de cuir, {hero.LootOr} pièces d'or et {nbPotions} potions.\n");
                            Console.WriteLine("\nVous pansez vos blessures.\n");
                            blessuresHeros = 0;

                            if (hero.LootCuir >= 2 && bouclier == false)
                            {
                                string faireBouclier;
                                Console.WriteLine("Vous pouvez utiliser deux morceaux de cuir pour concevoir un bouclier. Le bouclier absorbe 5 dégâts avant de se casser.");
                                Console.WriteLine("Souhaitez-vous concevoir un bouclier?");
                                faireBouclier = Console.ReadLine();
                                if (faireBouclier == "oui" || faireBouclier == "Oui" || faireBouclier == "OUI")
                                {
                                    bouclier = true;
                                    degatsBouclier = 5;
                                    Console.WriteLine("Vous vous équippez d'un bouclier.");
                                }
                            }

                            if (hero.LootOr > 0)
                            {
                                    string acheterPotion;
                                do
                                {
                                    Console.WriteLine("Souhaitez-vous acheter une potion pour 1 pièce d'or?");
                                    acheterPotion = Console.ReadLine();
                                    if (acheterPotion == "oui" || acheterPotion == "Oui" || acheterPotion == "OUI")
                                    {
                                        nbPotions++;
                                        hero.LootOr--;
                                        Console.WriteLine($"Vous achetez une potion. Vous avez {nbPotions} potions.");
                                    }
                                } while ((acheterPotion == "oui" || acheterPotion == "Oui" || acheterPotion == "OUI") && hero.LootOr > 0);
                            }

                            Console.Clear();

                            Console.WriteLine("-------------------- Forêt de Shorewood --------------------\n");
                            for (int i = 0; i < 15; i++)
                            {
                                for (int j = 0; j < 15; j++)
                                {
                                    if (zone[i, j] == " ||. ") Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    if (zone[i, j] == "  X  ") Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(zone[i, j]);
                                    Console.ResetColor();
                                }
                                Console.WriteLine("\n");
                            }
                        }
                    }
                }
                foreach (Monstre m in morts)
                {
                    listeMonstres.Remove(m);
                }
            }
            if (listeMonstres.Count() <= 0) Console.WriteLine("Vous avez gagné!");
        }
    }
}