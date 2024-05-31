using System;
using System.Reflection.Metadata.Ecma335;

namespace ArenaGame
{
    public class Weapon
    {
        public string Type { get; private set; }
        public int Damage { get; private set; }
        public string SpecialAbility { get; private set; }
        public Weapon(string type, int damage, string specialAbility)
        {
            Type = type;
            Damage = damage;
            SpecialAbility=specialAbility;

        }
        public virtual int UseWeaponSpecialAbility(Hero hero)
        {
            Console.WriteLine("Someone used the special ability of their weapon.");
            return Damage;
        }
      
    }
}
