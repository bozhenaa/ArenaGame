using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Sword : Weapon
    {
        public Sword() : base("Sword", 30, "Slash")
        {

        }
        public override int UseWeaponSpecialAbility(Hero hero)
        {
            Console.WriteLine($"{hero.Name} used their special ability and slashed their" +
                $" opponent on two!");
            return 100;
        }
    }
}
