using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonType : MonoBehaviour
{
    [SerializeField] private PlayerGun PlayerGun;
    [SerializeField] private GameObject regularBulletPrefab; // Prefab for the regular bullet
    [SerializeField] private GameObject explosiveBulletPrefab; // Prefab for the explosive bullet
    [SerializeField] private GameObject ricochetBulletPrefab; // Prefab for the ricochet bullet

    public void SelectRegularBullet()
    {
        PlayerGun.SetBulletType(regularBulletPrefab); 
    }

    public void SelectExplosiveBullet()
    {
        PlayerGun.SetBulletType(explosiveBulletPrefab); 
    }

   public void SelectRicochetBullet()
    {
        PlayerGun.SetBulletType(ricochetBulletPrefab); 
    }
}
