using TMPro;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private PlayerCombar playerCombat;

    private void Start()
    {
        currentHealth = maxHealth;
        playerCombat = GameObject.FindWithTag("Player").GetComponent<PlayerCombar>();
        
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0 && playerCombat != null)
        {
                playerCombat.LevelUP();


            Destroy(gameObject);
        }

    }
}

