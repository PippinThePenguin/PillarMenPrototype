using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float damage = 5;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScript script = collision.gameObject.GetComponent<EnemyScript>();            
            if (script != null)
                script.Health -= damage;
        }       
        gameObject.SetActive(false);
    }
}
