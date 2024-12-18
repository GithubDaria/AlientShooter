using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allient : MonoBehaviour
{
    [SerializeField] private string AllientName;
    [SerializeField] private Animator AlientAnimatorController;


    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Color originalColor;

    public Color flashColor = Color.red;  
    public float flashDuration = 0.1f;   
    private void Start()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originalColor = skinnedMeshRenderer.material.color;
        AlientAnimatorController = GetComponent<Animator>();
    }
    public void TakeDamage()
    {
        AlientAnimatorController.SetTrigger("HitRecieved");
        Flash();
    }
    public void Flash()
    {
        if (skinnedMeshRenderer == null) return;

        skinnedMeshRenderer.material.color = flashColor;

        Invoke(nameof(ResetColor), flashDuration);
    }

    private void ResetColor()
    {
        if (skinnedMeshRenderer == null) return;

        skinnedMeshRenderer.material.color = originalColor;
    }
}
