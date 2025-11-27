using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public interface IEquipmentChest
    {
        IWeapon GetWeapon();
        IArmor GetArmor();
    }
    public class WarriorEquipmentChest : IEquipmentChest
    {
        public IWeapon GetWeapon() => new Sword();
        public IArmor GetArmor() => new HeavyArmor();
    }
    public class ThiefEquipmentChest : IEquipmentChest
    {
        public IWeapon GetWeapon() => new Bow();
        public IArmor GetArmor() => new LightArmor();
    }
    public class MagicalEquipmentChest : IEquipmentChest
    {
        public IWeapon GetWeapon() => new Staff();
        public IArmor GetArmor() => new Robe();
    }
}
