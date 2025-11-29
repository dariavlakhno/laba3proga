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
        private readonly GameLogger logger;

        public HeavyArmor()
        {
            this.logger = GameLogger.GetInstance();
            this.defense = 0.3f;
        }

        public float GetDefense()
        {
            return defense;
        }

        public void Use()
        {
            logger.Log("Тяжелая броня блокирует значительную часть урона");
        }
    }
    public class LightArmor : IArmor
    {
        private float defense;
        private readonly GameLogger logger;

        public LightArmor()
        {
            this.logger = GameLogger.GetInstance();
            this.defense = 0.2f;
        }

        public float GetDefense()
        {
            return defense;
        }

        public void Use()
        {
            logger.Log("Легкая броня блокирует урон");
        }
    }
    public class Robe : IArmor
    {
        private float defense;
        private readonly GameLogger logger;

        public Robe()
        {
            this.logger = GameLogger.GetInstance();
            this.defense = 0.1f;
        }

        public float GetDefense()
        {
            return defense;
        }

        public void Use()
        {
            logger.Log("Роба блокирует немного урона");
        }
    }
}
