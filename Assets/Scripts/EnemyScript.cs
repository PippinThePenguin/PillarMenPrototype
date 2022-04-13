using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    
    [SerializeField] private float health, maxHealth;
    [SerializeField] private bool healthBarActive = false;
    [SerializeField] private Slider healthBar;
    [SerializeField] private SceneScript scene;
    [SerializeField] private GameObject ragdoll, normal;
    public static event Action<GameObject> EnemyDied;
    public bool Alive = true;
    private void Awake()
    {
        EnemyDied = null;
    }
    private void Start()
    {
        health = maxHealth;
        Alive = true;

        healthBar.maxValue = maxHealth;
        healthBar.minValue = 0f;
        healthBar.value = health;
        healthBar.gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;
        if (health <= 0f)
        {
            Alive = false;
            scene.GotOne(gameObject);            
            if (ragdoll != null)
            {                
                healthBar.gameObject.SetActive(false);                
                healthBarActive = false;                
                ragdoll.SetActive(true);                
                normal.SetActive(false);
                transform.GetComponent<CapsuleCollider>().enabled = false;
            }
            EnemyDied?.Invoke(gameObject);
            //gameObject.SetActive(false);
        }
        if (!healthBarActive && Alive)
        {
            
            healthBar.gameObject.SetActive(true);
            healthBarActive = true;
        }
    }
}
