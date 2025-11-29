using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float speed = 20f;
    public int damage = 40;
    public float lifeTime = 1.5f; 

    [Header("Setup")]
    public Rigidbody2D rb;
    public GameObject impactEffect; 
    void Start()
    {
       
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
       
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.Takedamage(damage);
        }

        if (impactEffect != null)
        {
            
            GameObject clone = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(clone, 0.5f);
        }

        Destroy(gameObject);
    }
}