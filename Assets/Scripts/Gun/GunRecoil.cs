using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunRecoil : MonoBehaviour
{
    private float returnDuration = 0.2f;    

    private float rotationRecoil = 25f;     
    private float rotationDuration = 0.1f; 

    private Vector3 initialPosition;      
    private Vector3 initialRotation;       

    private void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localEulerAngles;
    }

    public void ApplyRecoil()
    {
        transform.DOLocalRotate(new Vector3(initialRotation.x + rotationRecoil, initialRotation.y, initialRotation.z), rotationDuration)
            .OnComplete(() =>
            {
                transform.DOLocalRotate(initialRotation, returnDuration);
            });
    }
}
