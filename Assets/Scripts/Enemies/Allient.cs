using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allient : MonoBehaviour
{
    [SerializeField] private string AllientName;
    [SerializeField] private Animator AlientAnimatorController;


    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Color originalColor;

    public Color flashColor = Color.red;  // Color to flash
    public float flashDuration = 0.1f;   // Duration of the flash
    private void Start()
    {
        // Cache the Renderer and original material color
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

        // Change the material color to the flash color
        skinnedMeshRenderer.material.color = flashColor;

        // Reset the color after a delay
        Invoke(nameof(ResetColor), flashDuration);
    }

    private void ResetColor()
    {
        if (skinnedMeshRenderer == null) return;

        // Revert to the original color
        skinnedMeshRenderer.material.color = originalColor;
    }
}
