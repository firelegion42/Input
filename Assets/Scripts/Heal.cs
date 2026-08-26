using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float _healingAmount;

    private void OnTriggerEnter(Collider other)
    {
        IHealable obj = other.GetComponent<IHealable>();
        if (obj != null)

            obj.Heal(_healingAmount);
        Destroy(gameObject);
    }
}
