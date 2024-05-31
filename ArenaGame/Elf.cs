using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Elf : Hero
    {
        private const int AvoidAttackChance = 40;
        private const int IncreaseAttackChance = 20;
        private const int BigIncreaseAttackChance = 5;
        int attackCount = 0;

        public Elf() : this("Legolas")
        {

        }
        public Elf(string name) : base(name)
        {
         
        }

        public override int Attack()
        {
            int attack = base.Attack();
            attackCount = attackCount + 1;
            if (Weapon != null)
            {
                if (attackCount % 4 == 0)
                {
                    attackCount += Weapon.UseWeaponSpecialAbility(this);
                }
                attack += Weapon.Damage;
            }
            if (ThrowDice(IncreaseAttackChance))
            {
                attack = attack * 115 / 100;
            }
            else if (ThrowDice(BigIncreaseAttackChance))
            {
                attack = attack * 200 / 100;
            }
            
            return attack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            if (ThrowDice(AvoidAttackChance)) incomingDamage = 0;
            base.TakeDamage(incomingDamage);
        }
    }
}
