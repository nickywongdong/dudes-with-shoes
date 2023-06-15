using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float _initialHealth;
    GameObject _explosion;
    float _currentHealth;
    public static event System.Action<bool> OnGameOver;

    private void Awake()
    {
        _currentHealth = _initialHealth;
    }

    public void ApplyDamage(float damage)
    {
        if ( _currentHealth < 0) 
        {
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth <=0 )
        {
            Destruct();
        }
    }

    void Destruct()
    {
        var _explosion = Instantiate(Resources.Load<GameObject>("Prefabs/EEEEXPLOSION"), transform.position, Quaternion.identity);
        var tag = gameObject.tag;

        Debug.Log("Destroying game object");
        Destroy(gameObject);
        var explosionParticles = _explosion.GetComponent<ParticleSystem>();
        explosionParticles.Play();
        CameraShaker.Invoke();
        Destroy(_explosion, (explosionParticles.main.duration));

        if (tag == "EndObjective")
        {
            OnGameOver?.Invoke(true);
        }
    }
}
