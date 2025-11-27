using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public class PlayableCharacter
    {
        private GameLogger logger;
        public string Name { get; private set; }
        public CharacterClass CharacterClass { get; private set; }
        public IWeapon Weapon { get; private set; }
        public IArmor Armor { get; private set; }
        public int Health { get; private set; }
        private PlayableCharacter(Builder builder)
        {
            logger = GameLogger.GetInstance();
            Name = builder.Name;
            CharacterClass = builder.CharacterClass;
            Weapon = builder.Weapon;
            Armor = builder.Armor;
            Health = (int)builder.CharacterClass;
        }
        public class Builder
        {
            public string Name { get; private set; }
            public CharacterClass CharacterClass { get; private set; }
            public IWeapon Weapon { get; private set; }
            public IArmor Armor { get; private set; }
            public Builder SetName(string name)
            {
                Name = name;
                return this;
            }
            public Builder SetCharacterClass(CharacterClass characterClass)
            {
                CharacterClass = characterClass;
                return this;
            }
            public Builder SetWeapon(IWeapon weapon)
            {
                Weapon = weapon;
                return this;
            }
            public Builder SetArmor(IArmor armor)
            {
                Armor = armor;
                return this;
            }
            public PlayableCharacter Build()
            {
                return new PlayableCharacter(this);
            }
        }
        public void TakeDamage(int damage)
        {
            int reducedDamage = (int)Math.Round(damage * (1 - Armor.GetDefense()));
            if (reducedDamage < 0) reducedDamage = 0;
            Health -= reducedDamage;
            Armor.Use();
            logger.Log($"{Name} получил урон: {reducedDamage}");
            if (Health > 0)
            {
                logger.Log($"У {Name} осталось {Health} здоровья");
            }
        }
        public void Attack(Enemy enemy)
        {
            logger.Log($"{Name} атакует врага {enemy.Name}");
            Weapon.Use();
            enemy.TakeDamage(Weapon.GetDamage());
        }
        public bool IsAlive() => Health > 0;
    }
}
