using TMPro;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Player player;
    public GameObject[] dropItemsPrefabs;

    [Header("Drop Settings")]
    [Range(0f, 100f)]
    public float dropChance = 30f;


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
            Radomiten();
            Destroy(gameObject);
            Application.Quit();
        }

    }


    public void Radomiten()
    {
        float randomValue = Random.Range(0f, 100f);
        if (randomValue <= dropChance && dropItemsPrefabs.Length > 0)
        {
            // สุ่มไอเทมที่จะดรอป
            int randomIndex = Random.Range(0, dropItemsPrefabs.Length);
            Instantiate(dropItemsPrefabs[randomIndex], transform.position, Quaternion.identity);
            Debug.Log($"📦 Monster dropped: {dropItemsPrefabs[randomIndex].name}");
        }
        else
        {
            Debug.Log("❌ No item dropped");
        }
        
    }

}

