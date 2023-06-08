using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var HitTransform = collision.transform;
        Debug.Log(HitTransform.tag);
        if (HitTransform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            HitTransform.GetComponent<PlayerHealth>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
