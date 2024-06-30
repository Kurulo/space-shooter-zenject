using UnityEngine;

public class EnemyHealthBehaviour : MonoBehaviour
{
    [SerializeField] private int _totalHealth;
    
    private EnemyHealth _health;
    private Transform _transform;

    private void Start()
    {
        _health = new EnemyHealth(_totalHealth);

        _transform = GetComponent<Transform>();
    }
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponentInParent<PlayerWeapon>())
        {
            _health.TakeDamage(1);

            if (_health.Health <= 0)
            {
                _transform.parent.gameObject.SetActive(false);
            }

            Debug.Log($"Enemy Health: {_health.Health.ToString()}");
        }
    }
}
