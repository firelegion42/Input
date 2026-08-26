using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        Idamageable obj = other.GetComponent<Idamageable>();
        if(obj != null)
        {
            obj.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

}
