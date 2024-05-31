using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Knight : Hero
    {
        const int BlockDamageChance = 10;
        private const int ExtraDamageChance = 5;
        private int attackCount = 0;
        public Knight() : this("Sir John")
        {
            
        }

        public Knight(string name) : base (name)
        {
            
        }

        public override void TakeDamage(int incomingDamage)
        {
            if (Weapon != null)
            {
                base.TakeDamage(5);
            }
            //Apply armor
            int damageReduceCoef = Random.Shared.Next(20, 61);
            incomingDamage = 
                incomingDamage - ((incomingDamage * damageReduceCoef) / 100);
            //Apply special skill: block
            if (ThrowDice(BlockDamageChance)) incomingDamage = 0;
            //Default behavior
            base.TakeDamage(incomingDamage);

        }

        public override int Attack()
        {
            attackCount = attackCount + 1;
            int attack = base.Attack();
            if (Weapon != null)
            {
                if (attackCount % 4 == 0)
                {
                    attackCount += Weapon.UseWeaponSpecialAbility(this);
                }
                attack += Weapon.Damage;      
            }
            if (ThrowDice(ExtraDamageChance)) attack = attack * 150 / 100;
            return attack;
        }
    }
}
