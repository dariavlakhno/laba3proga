using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public class HeavyArmor : IArmor
    {
        private float defense;
        private GameLogger logger;
        public HeavyArmor()
        {
            defense = 0.3f;
            logger = GameLogger.GetInstance();
        }
        public float GetDefense() => defense;
        public void Use()
        {
            logger.Log("Тяжелая броня блокирует значительную часть урона");
        }
    }
    public class LightArmor : IArmor
    {
        private float defense;
        private GameLogger logger;
        public LightArmor()
        {
            defense = 0.2f;
            logger = GameLogger.GetInstance();
        }
        public float GetDefense() => defense;
        public void Use()
        {
            logger.Log("Легкая броня блокирует урон");
        }
    }
    public class Robe : IArmor
    {
        private float defense;
        private GameLogger logger;
        public Robe()
        {
            defense = 0.1f;
            logger = GameLogger.GetInstance();
        }
        public float GetDefense() => defense;
        public void Use()
        {
            logger.Log("Роба блокирует немного урона");
        }
    }
}
