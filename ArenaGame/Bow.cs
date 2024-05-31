using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Bow : Weapon
    {
        public Bow() :base("Bow", 20, "Shoot an arrow")
		{

		}
        public override int UseWeaponSpecialAbility(Hero hero)
        {
            Console.WriteLine($"{hero.Name} used their special ability and shoot a fire " +
                $"arrow at their enemy.");
            return 40;
        }
    }
}