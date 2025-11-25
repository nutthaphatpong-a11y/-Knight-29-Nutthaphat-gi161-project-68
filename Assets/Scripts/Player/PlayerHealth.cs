using System;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public TMP_Text healthText;

    private void Start()
    {
        healthText.text = "HP : " + currentHealth + " / " + maxHealth;
    }
    public void ChangeHealth(int amout)
    {
        currentHealth += amout;
        healthText.text = "HP : " + currentHealth + " / " + maxHealth;

        if (currentHealth <= 0) 
        {
            gameObject.SetActive(false);
        }
    }

}
