using TMPro;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private Player player;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0 && player != null)
        {
            player.AddExp(1);


            Destroy(gameObject);
        }

    }
}

