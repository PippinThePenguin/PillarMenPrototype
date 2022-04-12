using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float health, maxHealth;
    [SerializeField] private bool healthBarActive = false;
    [SerializeField] private Transform healthBar;
    public static event Action<GameObject> EnemyDied;
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0f)
        {
            EnemyDied?.Invoke(gameObject);
            gameObject.SetActive(false);
        }
        if (!healthBarActive)
        {

        }
    }
}
