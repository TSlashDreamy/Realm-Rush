using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    int currentHealth;


    void OnEnable()
    {
        currentHealth = maxHealth;
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
            gameObject.SetActive(false);
        }
    }
}
