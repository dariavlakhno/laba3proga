using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    using System;
    public class GameLogger
    {
        private static GameLogger instance;
        private GameLogger() { }
        public static GameLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new GameLogger();
            }
            return instance;
        }
        public void Log(string message)
        {
            Console.WriteLine($"[GAME LOG]: {message}");
        }
    }
}
