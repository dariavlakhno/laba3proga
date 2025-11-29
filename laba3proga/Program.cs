using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Создайте своего персонажа:");

            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();

            Console.WriteLine("Выберите класс из списка: " + string.Join(", ", Enum.GetValues(typeof(CharacterClass)).Cast<CharacterClass>()));
            CharacterClass characterClass = (CharacterClass)Enum.Parse(typeof(CharacterClass), Console.ReadLine(), true);

            IEquipmentChest startingEquipmentChest = GetChest(characterClass);
            IArmor startingArmor = startingEquipmentChest.GetArmor();
            IWeapon startingWeapon = startingEquipmentChest.GetWeapon();

            PlayableCharacter player =
                new PlayableCharacter.Builder()
                    .SetName(name)
                    .SetCharacterClass(characterClass)
                    .SetArmor(startingArmor)
                    .SetWeapon(startingWeapon)
                    .Build();

            GameLogger gameLogger = GameLogger.GetInstance();
            gameLogger.Log(string.Format("{0} очнулся на распутье!", player.GetName()));

            Console.WriteLine("Куда вы двинетесь? Выберите локацию: ({0}, {1})", Forest.NAME, DragonLogovo.NAME);
            string locationName = Console.ReadLine();
            Location location = GetLocation(locationName);

            Enemy enemy = location.EnterLocation(player);

            Random random = new Random();
            while (player.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine("Введите что-нибудь чтобы атаковать!");
                Console.ReadLine();
                player.Attack(enemy);

                bool stunned = random.Next(2) == 0; // 50% шанс оглушения
                if (stunned)
                {
                    gameLogger.Log(string.Format("{0} был оглушен атакой {1}!", enemy.GetName(), player.GetName()));
                    continue;
                }
                enemy.Attack(player);
            }

            Console.WriteLine();

            if (!player.IsAlive())
            {
                gameLogger.Log(string.Format("{0} был убит...", player.GetName()));
                return;
            }

            gameLogger.Log(string.Format("Злой {0} был побежден! {1} отправился дальше по тропе судьбы...", enemy.GetName(), player.GetName()));
        }

        // получаем стартовый сундук в зависимости от класса персонажа
        private static IEquipmentChest GetChest(CharacterClass characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.MAGE:
                    return new MagicalEquipmentChest();
                case CharacterClass.WARRIOR:
                    return new WarriorEquipmentChest();
                case CharacterClass.THIEF:
                    return new ThiefEquipmentChest();
                default:
                    throw new ArgumentException();
            }
        }

        // получаем локацию в зависимости от выбора игрока
        private static Location GetLocation(string locationName)
        {
            switch (locationName.ToLower())
            {
                case Forest.NAME:
                    return new Forest();
                case DragonLogovo.NAME:
                    return new DragonLogovo();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
