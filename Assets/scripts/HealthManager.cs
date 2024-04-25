using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : GameManager
{
    public static int health;
    public TMP_Text healthText;
    
    void Start()
    {
        
        health = 50;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }

    
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            health = 0;
            RecordDeath();
        }
        UpdateHealthUI();
    }

    
    public void Heal(int healAmount)
    {
        health += healAmount;
        UpdateHealthUI();
    }

    
    
}
