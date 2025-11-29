using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Transform aimTransform;
    private Camera mainCam;
    private Vector3 initialScale;

    private void Awake()
    {
        mainCam = Camera.main;
        initialScale = aimTransform.localScale;
    }

    private void Update()
    {
        if (aimTransform != null && mainCam != null)
        {
            HandleAiming();
        }
    }

    private void HandleAiming()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        
        float yScale = Mathf.Abs(initialScale.y);

        if (mousePos.x < aimTransform.position.x)
        {
            
            yScale = -yScale;
        }
        else
        {
            
            yScale = +yScale;
        }

        aimTransform.localScale = new Vector3(initialScale.x, yScale, initialScale.z);
    }
}