using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerController _playerPrefab;

    public override void InstallBindings()
    {
       BindPlayer();
    }
    
    private void BindPlayer()
    {
        Container.Bind<PlayerSettings>().AsSingle();
        Container.Bind<PlayerFactory>().AsSingle();
    }
}