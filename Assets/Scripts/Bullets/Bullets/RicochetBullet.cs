using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetBullet : MonoBehaviour 
{
    private int MaxBounceCount = 3;  
    private float BulletMoveSpeed = 50;
    private int BounceCount = 0;
    private float lifetime = 5f;
    [SerializeField] private GameObject explosionEffect;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * BulletMoveSpeed;
        Destroy(this.gameObject, lifetime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (BounceCount < MaxBounceCount)
        {
            Vector3 reflectDirection = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = reflectDirection; 

            BounceCount++; 
            PlayExplosionEffect();
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Allient allient = collision.gameObject.GetComponent<Allient>();
                if (allient != null)
                {
                    allient.TakeDamage();
                }
            }
        }
        else
        {
           
            Destroy(gameObject);
        }
    }
    private void PlayExplosionEffect()
    {
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
        }
    }
}
