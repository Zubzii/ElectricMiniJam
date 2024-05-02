using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    public GameObject healthBar;
    private Image healthBarImage;
    private int damageAmount;
    private Collider2D shieldCollider;
    public GameObject shield;

    private void Awake()
    {
        healthBarImage = healthBar.GetComponent<Image>();
    }

    void Start()
    {
        maxHealth = 100;
        damageAmount = 10;
        currentHealth = maxHealth;
        shieldCollider = shield.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!shieldCollider.enabled && collision.CompareTag("Projectile"))
        {
            TakeDamage(damageAmount);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Health"))
        {
            increaseHealth(30);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            TakeDamage(damageAmount*2);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        updateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(2);
    }

    public void updateHealthBar()
    {
        healthBarImage.fillAmount = (float)currentHealth / 100f;
    }

    void increaseHealth(int health)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += health;
        }
        updateHealthBar();
    }
}
