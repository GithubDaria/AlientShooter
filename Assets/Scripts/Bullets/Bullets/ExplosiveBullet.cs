using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour 
{
    private float lifetime = 5f;
    private float explosionRadius = 5f; 
    [SerializeField] private GameObject explosionEffect;

    private float BulletMoveSpeed = 50;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        transform.position += Vector3.forward * BulletMoveSpeed * Time.deltaTime; //fix here later 
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayExplosionEffect();
        Explode();
        Destroy(this.gameObject);
    }
    private void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Allient allient = hitCollider.GetComponent<Allient>();
                if (allient != null)
                {
                    allient.TakeDamage();
                }
            }
        }

        Destroy(gameObject);
    }
    private void PlayExplosionEffect()
    {
        if (explosionEffect != null)
        {
            FindObjectOfType<CameraShake>().ShakeCamera();
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().Play();
            Destroy(explosion, 1f); 
        }
    }
}
