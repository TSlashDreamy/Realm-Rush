using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;

    [Tooltip("Adds amount to enemy MaxHealth, when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

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
            maxHealth += difficultyRamp;
            gameObject.SetActive(false);
        }
    }
}
