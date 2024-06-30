using UnityEngine;
using Zenject;

public class WeaponInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindWeaponFactory();
    }

    private void BindWeaponFactory()
    {
        Container.
            Bind<IWeaponFactory>().
            To<WeaponFactory>().
            AsSingle();
    }
}