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
        private string name;
        private CharacterClass characterClass;
        private IWeapon weapon;
        private IArmor armor;
        private int health;

        // конструктор принимает в себя билдера из которого и берет значения полей
        private PlayableCharacter(Builder builder)
        {
            this.logger = GameLogger.GetInstance();
            this.name = builder.Name;
            this.characterClass = builder.CharacterClass;
            this.weapon = builder.Weapon;
            this.armor = builder.Armor;
            this.health = GetStartingHealth(characterClass);  // Вызываем метод этого же класса!
        }

        // Метод для получения стартового здоровья
        private int GetStartingHealth(CharacterClass characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.WARRIOR:
                    return 100;
                case CharacterClass.THIEF:
                    return 90;
                case CharacterClass.MAGE:
                    return 80;
                default:
                    return 0;
            }
        }

        // внутренний класс билдер
        public class Builder
        {
            internal string Name { get; private set; }
            internal CharacterClass CharacterClass { get; private set; }
            internal IWeapon Weapon { get; private set; }
            internal IArmor Armor { get; private set; }

            public Builder SetName(string name)
            {
                this.Name = name;
                return this;
            }

            public Builder SetCharacterClass(CharacterClass characterClass)
            {
                this.CharacterClass = characterClass;
                return this;
            }

            public Builder SetWeapon(IWeapon weapon)
            {
                this.Weapon = weapon;
                return this;
            }

            public Builder SetArmor(IArmor armor)
            {
                this.Armor = armor;
                return this;
            }

            public PlayableCharacter Build()
            {
                return new PlayableCharacter(this);
            }
        }

        // остальные методы без изменений...
        public void TakeDamage(int damage)
        {
            int reducedDamage = (int)Math.Round(damage * (1 - armor.GetDefense()));

            if (reducedDamage < 0)
                reducedDamage = 0;

            health -= reducedDamage;
            armor.Use();
            logger.Log(name + " получил урон: " + reducedDamage);

            if (health > 0)
            {
                logger.Log(string.Format("У {0} осталось {1} здоровья", name, health));
            }
        }

        public void Attack(Enemy enemy)
        {
            logger.Log(string.Format("{0} атакует врага {1}", name, enemy.GetName()));
            weapon.Use();
            enemy.TakeDamage(weapon.GetDamage());
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public string GetName()
        {
            return name;
        }
    }
}
