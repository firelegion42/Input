using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _gun;
    [SerializeField] private float _bulletSpeed;
        
    private GameObject _currentBullet;

    public void Shoot()
    {
        _currentBullet = Instantiate(_bullet, _gun.position, Quaternion.identity);


        Rigidbody currentVelocity = _currentBullet.GetComponent<Rigidbody>();
        currentVelocity.linearVelocity = _gun.up * _bulletSpeed;
        Destroy(_currentBullet, 1);
    }
    
}
