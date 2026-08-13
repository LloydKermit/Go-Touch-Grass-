using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyHealth : MonoBehaviour
{
    [Header("Stats")]
    public HealthBar healthBar;
    public int maxHealth = 300;
    public int currentHealth;

    [Header("IFrames")]
    public Color flashColor;
    public Color RegularColor;
    public float flashDur;
    public int numOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer TimmySprite;


    public GameObject deathEffect;
    public WinLose winLose;

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxHealth(maxHealth);
    }
    private IEnumerator iFrame()
    {
        triggerCollider.enabled = false;
        for (int temp = 0; temp < numOfFlashes; temp++)
        {
            TimmySprite.color = flashColor;
            yield return new WaitForSeconds(flashDur);
            TimmySprite.color = RegularColor;
            yield return new WaitForSeconds(flashDur);
        }
        yield return new WaitForSeconds(0.5f);
        triggerCollider.enabled = true;
    }
    public void TakeDamage(int damage)
    {
        StartCoroutine(iFrame());

        currentHealth -= damage;

        healthBar.setHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        var deathAni = Instantiate(deathEffect, transform.position, transform.rotation);

        Destroy(deathAni, 0.7f);

        Destroy(gameObject);

        winLose.Lose();
    }
}
