using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameOver GameOverScreen;

    float Health;
    public float MaxHealth = 100f;

    [Header("Damage Overlay")]
    public Image Overlay;
    public float Duration;
    public float FadeSpeed;

    private float DurationTimer;


    private void Start()
    {
        Health = MaxHealth;
        Overlay.color = new Color(Overlay.color.r, Overlay.color.g, Overlay.color.b, 0);
    }

    private void Update()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        if (Overlay.color.a > 0)
        {
            if (Health < 30)
            {
                return;
            }
            DurationTimer += Time.deltaTime;
            if (DurationTimer > Duration)
            {
                var TempAlpha = Overlay.color.a;
                TempAlpha -= Time.deltaTime * FadeSpeed;
                Overlay.color = new Color(Overlay.color.r, Overlay.color.g, Overlay.color.b, TempAlpha);
            }
        }
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        Debug.Log($"Took {Damage} damage, Health: {Health}");
        DurationTimer = 0;
        Overlay.color = new Color(Overlay.color.r, Overlay.color.g, Overlay.color.b, 1);
        if (Health <= 0)
        {
            GameOverScreen.Setup(false);
        }
    }

    public void HealDamage(float Damage)
    {
        Health += Damage;
        Debug.Log($"Healed {Damage} Health, Health: {Health}");
    }
}
