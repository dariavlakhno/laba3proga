using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    using System;
    public abstract class Location
    {
        protected GameLogger gameLogger = GameLogger.GetInstance();
        public Enemy EnterLocation(PlayableCharacter player)
        {
            gameLogger.Log(string.Format(
                "{0} отправился в {1}", player.GetName(), GetLocationName()
            ));
            Enemy enemy = SpawnEnemy();
            gameLogger.Log(string.Format(
                "У {0} на пути возникает {1}, начинается бой!", player.GetName(), enemy.GetName()
            ));
            return enemy;
        }
        protected abstract Enemy SpawnEnemy();
        protected abstract string GetLocationName();
    }
    public class Forest : Location
    {
        public const string NAME = "мистический лес";
        protected override Enemy SpawnEnemy()
        {
            return new Goblin();
        }
        protected override string GetLocationName()
        {
            return NAME;
        }
    }
    public class DragonLogovo : Location
    {
        public const string NAME = "логово дракона";
        protected override Enemy SpawnEnemy()
        {
            return new Dragon();
        }
        protected override string GetLocationName()
        {
            return NAME;
        }
    }
}
