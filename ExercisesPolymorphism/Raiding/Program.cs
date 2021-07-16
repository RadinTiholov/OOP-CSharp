using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                BaseHero hero = null;
                if (type == "Druid")
                {
                    hero = new Druid(name);
                }
                else if (type == "Paladin")
                {
                    hero = new Paladin(name);
                }
                else if (type == "Rogue")
                {
                    hero = new Rogue(name);
                }
                else if (type == "Warrior")
                {
                    hero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }
                heroes.Add(hero);
            }
            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                heroesPower += hero.Power;
            }
            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else 
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
