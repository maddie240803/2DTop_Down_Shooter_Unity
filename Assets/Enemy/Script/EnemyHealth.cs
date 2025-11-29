using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public int scoreValue = 10;

    [Header("Loot Settings")]
    public GameObject[] lootItems;

    [Range(0, 100)]
    public float dropChance = 10f;

    public void Takedamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scoreValue);
        }

        TryDropLoot();

        Destroy(gameObject);
    }

    void TryDropLoot()
    {
        if (lootItems.Length == 0) return;

        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= dropChance)
        {
            int randomIndex = Random.Range(0, lootItems.Length);
            GameObject itemToSpawn = lootItems[randomIndex];

            Instantiate(itemToSpawn, transform.position, Quaternion.identity);
        }
    }
}