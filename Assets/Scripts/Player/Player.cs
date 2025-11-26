using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    public int exp = 0;
    public int maxExp = 1;
    public int baseDamage = 1;
    public int currentHealth;
    public int maxHealth;
    public TMP_Text healthText;


    public PlayerMovement movement { get; private set; }
    public PlayerCombat combat { get; private set; }
    public PlayerHealth health { get; private set; }

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        combat = GetComponent<PlayerCombat>();
        health = GetComponent<PlayerHealth>();

        combat.Init(this);
        
    }

    public void AddExp(int amount)
    {
        exp += amount;

        if (exp >= maxExp)
        {
            exp = 0;
            maxExp++;
            level++;
            baseDamage++;

            Debug.Log($"🎉 Level UP! to {level}, Damage : {baseDamage}");
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        item item = other.GetComponent<item>();
        if (item != null)
        {
            item.Pickup(this);
        }
    }

    private void Start()
    {
        UpdateHealthUI();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        UpdateHealthUI();
        
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void UpdateHealthUI()
    {
        healthText.text = $"HP : {currentHealth} / {maxHealth}";
    }

    public void Heal(int value)
    {
        currentHealth += value;
        healthText.text = $"HP : {currentHealth} / {maxHealth}";
    }
}
