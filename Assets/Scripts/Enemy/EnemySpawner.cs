using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Waves[] _waves;
    
    private int _currentWaveIndex = 0;
    private IWeaponFactory _weaponFactory;

    [Inject]
    public void Construct(IWeaponFactory weaponFactory)
    {
        _weaponFactory = weaponFactory;
    }
    
    private void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        Waves CurrentWave = _waves[_currentWaveIndex];

        for (int i = 0; i < CurrentWave.Enemies.Count; i++)
        {
            GameObject enemy = Instantiate(CurrentWave.Enemies[i], 
                CurrentWave.SpawnPoints[i].position, Quaternion.identity, null);
            
            _weaponFactory.Create(WeaponType.DoubleLaser, WeaponOwner.Enemy, enemy.transform);
            
            enemy.GetComponent<EnemyMoving>().SetTargetPosition(CurrentWave.EndPoints[i]);
        }
    }
}

[Serializable]
public class Waves
{
    public List<GameObject> Enemies;
    public List<Transform> SpawnPoints;
    public List<Transform> EndPoints;
}
