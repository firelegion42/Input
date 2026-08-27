using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;
    protected float _currentHealth;

    protected void Start()
    {
        _currentHealth = _maxHealth;
        Debug.Log(_currentHealth);
    }

    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);
        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    public abstract void Death();
}
