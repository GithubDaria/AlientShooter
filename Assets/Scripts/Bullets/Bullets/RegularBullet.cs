using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour
{
    private float BulletMoveSpeed = 50;
    private float lifetime = 5f;
    [SerializeField] private GameObject explosionEffect;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }
    void Update()
    {
        transform.position += Vector3.forward * BulletMoveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Allient allient = other.gameObject.GetComponent<Allient>();
            if (allient != null)
            {
                allient.TakeDamage();
            }
        }
        PlayExplosionEffect();
        Destroy(this.gameObject);
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
