using UnityEngine;

public interface IWeaponFactory
{
    void Load();
    void Create(WeaponType weaponType, WeaponOwner weaponOwner,  Transform container);
}
