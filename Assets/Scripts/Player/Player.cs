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
    public TMP_Text DMGText;
    public TMP_Text CoinText;
    public int Coin = 0;


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
            level++;
            maxExp = (level * 2);
            baseDamage++;
            maxHealth = maxHealth + (level * 2);
            healthText.text = $"HP : {currentHealth} / {maxHealth}";

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
        UpdateDMGUI();
        UpdateCoinUI();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthText.text = $"HP : {currentHealth} / {maxHealth}";

    }
    private void UpdateDMGUI()
    {
        DMGText.text = $"DMG : {baseDamage}";

    }
    private void UpdateCoinUI()
    {
        CoinText.text = $"Coin : {Coin}";

    }



    public void Heal(int value)
    {
        currentHealth += value;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }


        UpdateHealthUI();
        Debug.Log("You get health : " + currentHealth);
    }

    public void putonLongSword(int value)
    {
        baseDamage += value;
        UpdateDMGUI();
        Debug.Log( "You have equipped a long sword. Damage : " + baseDamage);
    }

    public void AddCoin(int value)
    {
        Coin += value;
        UpdateCoinUI();

        if (Coin >= 100)
        {
            Coin -= 100;
            Debug.Log("You buy Brave Sword");
            Debug.Log("You is ゆうしゃ");
            baseDamage = baseDamage * 100;
            Debug.Log(baseDamage);
            Debug.Log("Coin : " + Coin);
            UpdateDMGUI();
        }
        else if (Coin >= 0) 
        {
            Debug.Log("Coin : " + Coin);

        }

        
    }

    public void PlusExp(int value)
    {
        exp += value;
        Debug.Log("Get ExpStar Exp + : " + value);
    }

}
