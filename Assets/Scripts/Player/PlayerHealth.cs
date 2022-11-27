using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Panels panels;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] PlayerHealthBar playerHealthBar;

    public float currentHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
        UpdatePlayerHealthBar();
        StartCoroutine(HealthRegen());
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            panels.GameIsOver();
        }
    }

    public void UpdatePlayerHealthBar()
    {
        playerHealthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    IEnumerator HealthRegen()
    {
        yield return new WaitForSeconds(1f);
        if(currentHealth < 100)
        {
            currentHealth += 0.25f;
            UpdatePlayerHealthBar();
        }
        StartCoroutine(HealthRegen());
    }
}
