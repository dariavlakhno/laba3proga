using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public abstract class Enemy
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public abstract void TakeDamage(int damage);
        public abstract void Attack(PlayableCharacter player);

        public bool IsAlive() => Health > 0;
    }
    public class Goblin : Enemy
    {
        private GameLogger logger;
        public Goblin()
        {
            logger = GameLogger.GetInstance();
            Name = "Гоблин";
            Health = 50;
            Damage = 10;
        }
        public override void TakeDamage(int damage)
        {
            logger.Log($"{Name} получает {damage} урона!");
            Health -= damage;
            if (Health > 0)
                logger.Log($"У {Name} осталось {Health} здоровья");
        }
        public override void Attack(PlayableCharacter player)
        {
            logger.Log($"{Name} атакует {player.Name}!");
            player.TakeDamage(Damage);
        }
    }
    public class Dragon : Enemy
    {
        private GameLogger gameLogger;
        private float resistance;
        public Dragon()
        {
            gameLogger = GameLogger.GetInstance();
            Name = "Дракон";
            resistance = 0.2f;
            Health = 100;
            Damage = 30;
        }
        public override void TakeDamage(int damage)
        {
            damage = (int)Math.Round(damage * (1 - resistance));
            gameLogger.Log($"{Name} получает {damage} урона!");
            Health -= damage;
            if (Health > 0)
                gameLogger.Log($"У {Name} осталось {Health} здоровья");
        }
        public override void Attack(PlayableCharacter player)
        {
            gameLogger.Log("Дракон дышит огнем!");
            player.TakeDamage(Damage);
        }
    }
}
