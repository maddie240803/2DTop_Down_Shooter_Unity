using System.Collections;
using UnityEngine;

public class WeaponPowerHandler : MonoBehaviour
{
    [Header("Weapons Links")]
    public Spreadgun spreadGun;    
    public LaserGun laserGun;      
    public PlayerShoot normalGun;  

    [Header("Power Up Settings")]
    public float duration = 5f;

    [Header("Boosted Stats")]
    public int boostedPelletCount = 10;
    public float boostedBulletSpeed = 40f; 
    public int boostedLaserDamage = 50;

    
    private int originalPelletCount;
    private float originalSpreadSpeed;
    private int originalLaserDamage;
    private float originalNormalSpeed; 

    private bool isPoweredUp = false;

    void Start()
    {
       
        if (spreadGun != null)
        {
            originalPelletCount = spreadGun.pelletCount;
            originalSpreadSpeed = spreadGun.currentBulletSpeed;
        }
        if (laserGun != null)
        {
            originalLaserDamage = laserGun.damage;
        }
        if (normalGun != null) 
        {
            originalNormalSpeed = normalGun.currentBulletSpeed;
        }
    }
    

    public void ActivatePowerUp()
    {
        if (isPoweredUp) return;
        StartCoroutine(PowerUpRoutine());
    }

    IEnumerator PowerUpRoutine()
    {
        isPoweredUp = true;
        Debug.Log("POWER UP ACTIVATED!");

        
        if (spreadGun != null)
        {
            spreadGun.pelletCount = boostedPelletCount;
            spreadGun.currentBulletSpeed = boostedBulletSpeed;
        }
        if (laserGun != null)
        {
            laserGun.damage = boostedLaserDamage;
        }
        if (normalGun != null) 
        {
            normalGun.currentBulletSpeed = boostedBulletSpeed;
        }

       
        yield return new WaitForSeconds(duration);

        
        if (spreadGun != null)
        {
            spreadGun.pelletCount = originalPelletCount;
            spreadGun.currentBulletSpeed = originalSpreadSpeed;
        }
        if (laserGun != null)
        {
            laserGun.damage = originalLaserDamage;
        }
        if (normalGun != null)
        {
            normalGun.currentBulletSpeed = originalNormalSpeed;
        }


        Debug.Log("Power Up Ended...");
        isPoweredUp = false;
    }
}