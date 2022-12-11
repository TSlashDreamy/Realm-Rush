using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    int currentHealth;

    Enemy enemy;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();    
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();    
    }

    void ProcessHit()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            enemy.RewardGold();
            gameObject.SetActive(false);
        }
    }
}
