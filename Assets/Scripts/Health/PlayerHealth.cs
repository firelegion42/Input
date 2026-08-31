using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : Health, IDamageable, IHealable, IDataManager
{     

    public void Heal(float healingAmount)
    {
        _currentHealth += healingAmount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        Debug.Log(_currentHealth);
    }

    public override void Death()
    {
        Debug.Log(_currentHealth);
        Debug.Log("Dead");
        Destroy(gameObject);
    }

    public void LoadData(GameData data)
    {
        _maxHealth = data.maxHealth;
        _currentHealth = data.currentHealth;
    }

    public void SaveData(GameData data)
    {
        data.maxHealth = _maxHealth;
        data.currentHealth = _currentHealth;
    }
}
