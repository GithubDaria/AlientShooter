using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration = 0.5f;    
    [SerializeField] private float strength = 0.3f;   
    [SerializeField] private int vibrato = 10;        
    [SerializeField] private float randomness = 90f;  

    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = this.transform;
    }

    public void ShakeCamera()
    {
        if (cameraTransform != null)
        {
            cameraTransform.DOShakePosition(duration, strength, vibrato, randomness);
        }
    }
}
