using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public class WarriorEquipmentChest : IEquipmentChest
    {
        public IWeapon GetWeapon()
        {
            return new Sword();
        }

        public IArmor GetArmor()
        {
            return new HeavyArmor();
        }
    }
    public class MagicalEquipmentChest : IEquipmentChest
    {
        public IWeapon GetWeapon()
        {
            return new Staff();
        }

        public IArmor GetArmor()
        {
            return new Robe();
        }
    }
    public class ThiefEquipmentChest : IEquipmentChest
    {
        public IWeapon GetWeapon()
        {
            return new Bow();
        }

        public IArmor GetArmor()
        {
            return new LightArmor();
        }
    }
}
