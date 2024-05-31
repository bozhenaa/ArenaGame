using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Magician : Hero
    {
        private const int SpellChargeChance = 7;
        private const int BlockDamageSpell = 5;
        int attackCount = 0;

        public Magician() : this("Merlin the Mag")
        {

        }

        public Magician(string name) : base(name)
        {

        }

        public override void TakeDamage(int incomingDamage)
        {
            //Apply reduce damage
            int damageReduceCoef = Random.Shared.Next(20, 36);
            incomingDamage = incomingDamage - ((incomingDamage * damageReduceCoef) / 100);
            //Apply special magical block
            if (ThrowDice(BlockDamageSpell)) incomingDamage = 0;
            //Default behavior
            base.TakeDamage(incomingDamage);
        }

        public override int Attack()
        {
            int attack = base.Attack();
            attackCount=attackCount+1;
            if (Weapon != null)
            {
                if (attackCount % 4 == 0)
                {
                    attackCount += Weapon.UseWeaponSpecialAbility(this);
                }
                attack += Weapon.Damage;
            }
            if (ThrowDice(SpellChargeChance))
            {
                attack = attack *2;
            }
            Heal(StartingHealth * 3 / 100);
            return attack;
        }
    }
}
