using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    class Program
    {
        static void Main(string[] args)
        {
            RunGame();
        }
        static void RunGame()
        {
            Console.WriteLine("=== ЗАПУСК ИГРЫ ===");
            Console.WriteLine("Создайте своего персонажа:");
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine($"Выберите класс из списка: {string.Join(", ", Enum.GetNames(typeof(CharacterClass)))}");
            string classInput = Console.ReadLine();
            CharacterClass characterClass = (CharacterClass)Enum.Parse(typeof(CharacterClass), classInput, true);
            IEquipmentChest startingEquipmentChest = GetChest(characterClass);
            IArmor startingArmor = startingEquipmentChest.GetArmor();
            IWeapon startingWeapon = startingEquipmentChest.GetWeapon();
            PlayableCharacter player = new PlayableCharacter.Builder()
                .SetName(name)
                .SetCharacterClass(characterClass)
                .SetArmor(startingArmor)
                .SetWeapon(startingWeapon)
                .Build();
            GameLogger gameLogger = GameLogger.GetInstance();
            gameLogger.Log($"{player.Name} очнулся на распутье!");
            Console.WriteLine($"Куда вы двинетесь? Выберите локацию: ({Forest.Name}, {DragonBarrow.Name})");
            string locationName = Console.ReadLine();
            Location location = GetLocation(locationName);
            Enemy enemy = location.EnterLocation(player);
            Random random = new Random();
            while (player.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine("Введите что-нибудь чтобы атаковать!");
                Console.ReadLine();
                player.Attack(enemy);

                if (!enemy.IsAlive()) break;

                bool stunned = random.Next(2) == 0;
                if (stunned)
                {
                    gameLogger.Log($"{enemy.Name} был оглушен атакой {player.Name}!");
                    continue;
                }
                enemy.Attack(player);
            }
            Console.WriteLine();
            if (!player.IsAlive())
            {
                gameLogger.Log($"{player.Name} был убит...");
                return;
            }
            gameLogger.Log($"Злой {enemy.Name} был побежден! {player.Name} отправился дальше по тропе судьбы...");
        }
        static IEquipmentChest GetChest(CharacterClass characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage: return new MagicalEquipmentChest();
                case CharacterClass.Warrior: return new WarriorEquipmentChest();
                case CharacterClass.Thief: return new ThiefEquipmentChest();
                default: throw new ArgumentException("Неизвестный класс");
            }
        }
        static Location GetLocation(string locationName)
        {
            switch (locationName.ToLower())
            {
                case Forest.Name: return new Forest();
                case DragonBarrow.Name: return new DragonBarrow();
                default: throw new ArgumentException("Неизвестная локация");
            }
        }
    }
}
