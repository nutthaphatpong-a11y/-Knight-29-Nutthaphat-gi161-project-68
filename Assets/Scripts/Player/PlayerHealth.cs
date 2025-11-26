using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Player player;
    public int currentHealth;
    public int maxHealth;
    public TMP_Text healthText;

    public void Init(Player _player)
    {
        player = _player;
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
        player.Heal(value);
    }
}
