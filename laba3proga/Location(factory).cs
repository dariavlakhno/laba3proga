using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public abstract class Location
    {
        protected GameLogger gameLogger = GameLogger.GetInstance();
        public Enemy EnterLocation(PlayableCharacter player)
        {
            gameLogger.Log($"{player.Name} отправился в {GetLocationName()}");
            Enemy enemy = SpawnEnemy(); 
            gameLogger.Log($"У {player.Name} на пути возникает {enemy.Name}, начинается бой!");
            return enemy;
        }
        protected abstract Enemy SpawnEnemy();
        protected abstract string GetLocationName();
    }
    public class Forest : Location
    {
        public const string Name = "мистический лес";

        protected override Enemy SpawnEnemy() => new Goblin();
        protected override string GetLocationName() => Name;
    }
    public class DragonBarrow : Location
    {
        public const string Name = "логово дракона";

        protected override Enemy SpawnEnemy() => new Dragon();
        protected override string GetLocationName() => Name;
    }
}
