using TMPro;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Player player;
    public GameObject[] dropItemsPrefabs;

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
            if (dropItemsPrefabs.Length > 0)
            {
                int randomIndex = Random.Range(0, dropItemsPrefabs.Length);
                Instantiate(dropItemsPrefabs[randomIndex], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            Application.Quit();
        }


    }
}

