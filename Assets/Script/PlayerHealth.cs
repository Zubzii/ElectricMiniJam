using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    public GameObject healthBar;
    private Image healthBarImage;
    private int damageAmount;

    private void Awake()
    {
        healthBarImage = healthBar.GetComponent<Image>();
    }

    void Start()
    {
        maxHealth = 100;
        damageAmount = 10;
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(damageAmount);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Health: " + currentHealth);

        healthReduction();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
    }

    public void healthReduction()
    {
        healthBarImage.fillAmount = (float)currentHealth / 100f;
    }
}
