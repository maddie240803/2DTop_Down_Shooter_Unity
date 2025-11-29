using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [Header("Settings")]
    public Transform firePoint;
    public int damage = 20;
    public float range = 100f;
    public LineRenderer lineRenderer;

    [Header("Collision")]
    public LayerMask hitLayers; 

    [Header("VFX")]
    public GameObject impactEffect;

    void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShootLaser());
        }
    }

    IEnumerator ShootLaser()
    {
        lineRenderer.enabled = true;
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, range, hitLayers);

        if (hitInfo)
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);

            if (impactEffect != null)
            {
                Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
            }
            EnemyHealth enemy = hitInfo.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.Takedamage(damage);
            }
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * range);
        }

        yield return new WaitForSeconds(0.02f);
        lineRenderer.enabled = false;
    }
}