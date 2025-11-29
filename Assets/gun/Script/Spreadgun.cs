using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spreadgun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    [Header("Shotgun Settings")]
    public int pelletCount = 5;
    public float spreadAngle = 20f;
    public float currentBulletSpeed = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootShotgun();
        }
    }

    void ShootShotgun()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion rotationSpread = Quaternion.Euler(0, 0, randomAngle);
            Quaternion finalRotation = firePoint.rotation * rotationSpread;

            GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, finalRotation);

            Bullet bulletScript = newBullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.speed = currentBulletSpeed;
            }
        }
    }
}