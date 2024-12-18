using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private GameObject currentBullet;
    private bool CanShoot = true;
    [SerializeField] private Transform GunBarrel;

    [SerializeField] private Transform EnemyDirection;

    [SerializeField] private GunRecoil GunRecoil;

    [SerializeField] private CameraShake CameraShake;

    public void SetBulletType(GameObject bulletType)
    {
        currentBullet = bulletType;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanShoot)
        {
            FireBullet();
        }
    }
    public void FireBullet()
    {
        if (currentBullet != null)
        {
            Instantiate(currentBullet.gameObject, GunBarrel.position, Quaternion.identity);
            GunRecoil.ApplyRecoil();

            CanShoot = false;
            StartCoroutine(ShootingCooldown());
        }
    }

    IEnumerator ShootingCooldown()
    {
        yield return new WaitForSeconds(1f);
        CanShoot = true; 
    }
}
