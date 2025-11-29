using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public class Sword : IWeapon
    {
        private int damage;
        private readonly GameLogger logger;

        public Sword()
        {
            this.damage = 20;
            this.logger = GameLogger.GetInstance();
        }

        public int GetDamage()
        {
            return damage;
        }

        public void Use()
        {
            logger.Log("Удар мечом!");
        }
    }
    public class Bow : IWeapon
    {
        private int damage;
        private double criticalChance;
        private int criticalModifier;
        private readonly GameLogger logger;
        private readonly Random random;

        public Bow()
        {
            this.damage = 15;
            this.criticalChance = 0.3;
            this.criticalModifier = 2;
            this.logger = GameLogger.GetInstance();
            this.random = new Random();
        }

        public int GetDamage()
        {
            double roll = random.NextDouble();
            if (roll <= criticalChance)
            {
                logger.Log("Критический урон!");
                return damage * criticalModifier;
            }

            return damage;
        }

        public void Use()
        {
            logger.Log("Выстрел из лука!");
        }
    }
    public class Staff : IWeapon
    {
        private int damage;
        private double scatter;
        private readonly GameLogger logger;
        private readonly Random random;

        public Staff()
        {
            this.damage = 25;
            this.scatter = 0.2;
            this.logger = GameLogger.GetInstance();
            this.random = new Random();
        }

        public int GetDamage()
        {
            double roll = random.NextDouble();
            double factor = 1 + (roll * 2 * scatter - scatter);

            return (int)Math.Round(damage * factor);
        }

        public void Use()
        {
            logger.Log("Воздух накаляется, из посоха вылетает огненный шар!");
        }
    }
}
