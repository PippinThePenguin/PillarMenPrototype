using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public static event Action EnemyDied;
    public bool Alive = true;
    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                healthBar.value = health;
                Die();
            }
            else if (health >= maxHealth)
            {
                health = maxHealth;
            }
            else if (Alive && !healthBarActive)
            {
                healthBar.gameObject.SetActive(true);
                updateDelegat = RotateBar;
                healthBarActive = true;
            }
            healthBar.value = health;
        }
    }
    [SerializeField] private float maxHealth, ragdollForce;
    [SerializeField] private bool healthBarActive = false;
    [SerializeField] private Slider healthBar;
    [SerializeField] private SceneScript scene;
    [SerializeField] private GameObject ragdoll, normal;
    [SerializeField] private Rigidbody body;
    private float health;
    private delegate void UpdateDelegat();
    private UpdateDelegat updateDelegat;

    private void Awake()
    {
        EnemyDied = null;
        updateDelegat = null;
    }
    private void Start()
    {
        Health = maxHealth;
        Alive = true;
        transform.LookAt(scene.WayPoint);
        
        healthBar.maxValue = maxHealth;
        healthBar.minValue = 0f;
        healthBar.value = health;
        healthBar.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (updateDelegat != null)
            updateDelegat();
    }

    private void Die()
    {
        if (Alive)
        {
            Alive = false;
            scene.GotOne(gameObject);
            if (ragdoll != null)
            {
                healthBar.gameObject.SetActive(false);
                healthBarActive = false;
                ragdoll.SetActive(true);
                body.AddForce((UnityEngine.Random.value -0.5f)*ragdollForce, (UnityEngine.Random.value)* ragdollForce, (UnityEngine.Random.value -0.5f)* ragdollForce);
                normal.SetActive(false);
                transform.GetComponent<CapsuleCollider>().enabled = false;
            }
            EnemyDied?.Invoke();
        }
    }
    private void RotateBar()
    {
        healthBar.transform.LookAt(Camera.main.transform);
    }
}
