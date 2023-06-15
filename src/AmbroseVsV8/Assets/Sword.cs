using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] float _damage = 100f;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().TryGetComponent<Damageable>(out var damageable))
        {
            damageable.ApplyDamage(_damage);
        }
    }
}
