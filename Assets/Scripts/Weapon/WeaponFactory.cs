using UnityEngine;
using Zenject;


public class WeaponFactory : IWeaponFactory
{
    private readonly DiContainer _diContainer;
    
    private const string waySingleLaser = "Weapons/SingleLaser";
    private const string wayDoubleLaser = "Weapons/DoubleLaser";
    private const string wayTripleLaser = "Weapons/TripleLaser";

    private GameObject _singleLaser;    
    private GameObject _doubleLaser;
    private GameObject _tripleLaser;    
    
    private WeaponFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
        
        Load();
    }
    
    public void Load()
    {
        _singleLaser = Resources.Load<GameObject>(waySingleLaser);
        _doubleLaser = Resources.Load<GameObject>(wayDoubleLaser);
        _tripleLaser = Resources.Load<GameObject>(wayTripleLaser);
    }
    
    public void Create(WeaponType weaponIndex, WeaponOwner weaponOwner, Transform container)    
    {
        GameObject weapon;
        switch (weaponIndex )
        {
            case WeaponType.SingleLaser:
                weapon = _diContainer.InstantiatePrefab(
                    _singleLaser, container.position, Quaternion.identity, container);

                AddOwnerOfWeapon(weapon, weaponOwner);
                break;

            case WeaponType.DoubleLaser:
                 weapon = _diContainer.InstantiatePrefab(
                    _doubleLaser, container.position, Quaternion.identity, container);

                AddOwnerOfWeapon(weapon, weaponOwner);
                break;

            case WeaponType.TripleLaser:
                weapon = _diContainer.InstantiatePrefab(
                    _tripleLaser, container.position, Quaternion.identity, container);

                AddOwnerOfWeapon(weapon, weaponOwner);
                break;
        }
    }

    private void AddOwnerOfWeapon(GameObject weapon, WeaponOwner weaponOwner)
    {
        Debug.Log("Weapon name: " + weapon.transform.name);
        switch (weaponOwner)
        {        
            case WeaponOwner.Player:
                weapon.AddComponent<PlayerWeapon>();
                break;

            case WeaponOwner.Enemy:
                weapon.AddComponent<EnemyWeapon>();
                break;
        }
    }
}