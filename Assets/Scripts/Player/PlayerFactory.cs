using UnityEngine;
using Zenject;

public class PlayerFactory
{
    private const string _playerResourcePath = "Player/Player";

    private DiContainer _diContainer;
    
    public PlayerFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public PlayerController Create()
    {
        return _diContainer.InstantiatePrefabResourceForComponent<PlayerController>(_playerResourcePath);
    }
}
