using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 20f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthController playerHealth = other.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.AddHealth(healAmount); 
                Destroy(gameObject);
            }
        }
    }
}