using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 500;
    [SerializeField] GameObject deathVFX;

    
    public float GetHealth()
    {
        return health;
    }
    public void DealDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
            
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        else
        {
            GameObject deathVFXObject = Instantiate(deathVFX,  transform.position, Quaternion.identity);
            Destroy(deathVFXObject, 1f);
        }
    }
}
