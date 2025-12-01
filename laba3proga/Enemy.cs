using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public abstract class Enemy
    {
        protected string name;
        protected int health;
        protected int damage;
        public string GetName()
        {
            return name;
        }
        public int GetHealth()
        {
            return health;
        }
        public abstract void TakeDamage(int damage);
        public abstract void Attack(PlayableCharacter player);
        public bool IsAlive()
        {
            return health > 0;
        }
    }
    public class Goblin : Enemy
    {
        private GameLogger logger;
        public Goblin()
        {
            this.logger = GameLogger.GetInstance();
            this.name = "Гоблин";
            this.health = 50;
            this.damage = 10;
        }
        public override void TakeDamage(int damage)
        {
            logger.Log(string.Format("{0} получает {1} урона!", name, damage));
            health -= damage;
            if (health > 0)
                logger.Log(string.Format("У {0} осталось {1} здоровья", name, health));
        }
        public override void Attack(PlayableCharacter player)
        {
            logger.Log(string.Format("{0} атакует {1}!", name, player.GetName()));
            player.TakeDamage(damage);
        }
    }
    public class Dragon : Enemy
    {
        private readonly GameLogger gameLogger;
        private float resistance;
        public Dragon()
        {
            this.gameLogger = GameLogger.GetInstance();
            this.name = "Дракон";
            this.resistance = 0.2f;
            this.health = 100;
            this.damage = 30;
        }
        public override void TakeDamage(int damage)
        {
            damage = (int)Math.Round(damage * (1 - resistance));
            gameLogger.Log(string.Format("{0} получает {1} урона!", name, damage));
            health -= damage;
            if (health > 0)
                gameLogger.Log(string.Format("У {0} осталось {1} здоровья", name, health));
        }
        public override void Attack(PlayableCharacter player)
        {
            gameLogger.Log("Дракон дышит огнем!");
            player.TakeDamage(damage);
        }
    }
}
