using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{
    private float _health;

    public float Health => _health;

    public PlayerHealth(float health)
    {
        _health = health;
    }

    public void TakeDamage(float dmg)
    {
        _health -= dmg;
    }

    private bool CheckDeath()
    {
        return _health < 0;
    }
}
