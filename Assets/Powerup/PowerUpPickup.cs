using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WeaponPowerHandler powerHandler = other.GetComponent<WeaponPowerHandler>();

            if (powerHandler != null)
            {
                powerHandler.ActivatePowerUp();
                Destroy(gameObject);
            }
        }
    }
}