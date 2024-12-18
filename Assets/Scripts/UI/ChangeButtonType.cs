using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonType : MonoBehaviour
{
    [SerializeField] private PlayerGun PlayerGun;
    [SerializeField] private GameObject BulletTypePrefab;


    public void SelectBullet()
    {
        PlayerGun.SetBulletType(BulletTypePrefab); 
    }
}
