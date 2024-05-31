using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{ 
    public class Dagger : Weapon
    {
        public Dagger() : base("Dagger", 10, "Make a cut")
        {

        }
        public override int UseWeaponSpecialAbility(Hero hero)
        {
            Console.WriteLine($"{hero.Name} used their special ability and made " +
                $"a thousand cuts on their enemy.");
            return 50;
        }
    }
}
