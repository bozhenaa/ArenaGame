﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Rogue : Hero
    {
        private const int TripleDamageMagicLastDigit = 5;
        private const int HealEachNthRound = 3;
        private int attackCount;

        public Rogue(string name) : base (name)
        {
            attackCount = 0;
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
            if (attack % 25 == TripleDamageMagicLastDigit)
            {
                attack = attack * 3;
            }
            if (attackCount % HealEachNthRound == 0 && ThrowDice (25))
            {
                Heal(StartingHealth * 50 / 100);
            }
            return attack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            if (Weapon != null)
            {
                base.TakeDamage(5);
            }
            if (ThrowDice(30)) incomingDamage = 0;
            base.TakeDamage(incomingDamage);
        }
    }
}