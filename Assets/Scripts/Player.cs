using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Idamageable, IHealable
{
   
    [SerializeField] private float _maxHealth;

    private float _currentHealth;    

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float _damage)
    {
        _currentHealth -= _damage;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            Debug.Log("Deadge");
        }
        Debug.Log(_currentHealth);
    }

    public void Heal(float _healingAmount)
    {
        _currentHealth += _healingAmount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        Debug.Log(_currentHealth);
    }
}
