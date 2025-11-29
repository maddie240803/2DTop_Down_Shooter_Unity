using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float movespeed = 5f;
    private Rigidbody2D rb;
    private Camera mainCam;

    [Header("Dash Settings")]
    public float dashSpeed = 20f;      
    public float dashDuration = 0.2f;  
    public float dashCooldown = 1f;    

    private bool isDashing = false;    
    private bool canDash = true;       

    [Header("Assign in Inspector (Optional)")]
    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;

        if (playerTransform == null)
        {
            playerTransform = transform;
        }
    }

    private void Update()
    {
       
        if (isDashing)
        {
            return;
        }

       
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        rb.velocity = direction * movespeed;

       
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && direction != Vector2.zero)
        {
            StartCoroutine(Dash(direction));
        }

        HandlePlayerRotation();
    }

    private void HandlePlayerRotation()
    {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = 10f;
        Vector3 mousePos = mainCam.ScreenToWorldPoint(screenPos);
        mousePos.z = 0f; 
        Vector3 lookDir = (mousePos - playerTransform.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        playerTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private IEnumerator Dash(Vector2 direction)
    {
        canDash = false;
        isDashing = true; 

       
        float originalSpeed = movespeed;

        rb.velocity = direction * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        rb.velocity = direction * originalSpeed; 

        yield return new WaitForSeconds(dashCooldown);
        canDash = true; 
    }
}