using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3proga
{
    public interface IWeapon
    {
        int GetDamage();
        void Use();
    }
    public interface IArmor
    {
        float GetDefense();
        void Use();
    }
    public interface IEquipmentChest
    {
        IWeapon GetWeapon();
        IArmor GetArmor();
    }
}
