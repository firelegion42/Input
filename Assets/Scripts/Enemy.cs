using UnityEngine;

public class Enemy : MonoBehaviour, Idamageable
{

    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = _currentHealth - damage;
        Debug.Log(_currentHealth);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
