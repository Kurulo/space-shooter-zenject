using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image _healthImg;

    [Header("Settings")]
    [SerializeField] private float _totalHealth;

    private PlayerHealth _health;
    private Transform _transform;

    private void Start()
    {
        _health = new PlayerHealth(_totalHealth);

        _transform = GetComponent<Transform>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponentInParent<EnemyWeapon>())
        {
            _health.TakeDamage(1);

            _healthImg.fillAmount = _health.Health / _totalHealth; 

            if (_health.Health <= 0)    
            {
                _transform.parent.gameObject.SetActive(false);
            }

            Debug.Log($"Player Health: {_health.Health.ToString()}");
        }
    }
}
