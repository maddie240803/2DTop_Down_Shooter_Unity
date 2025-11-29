using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        var playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(_damageAmount);

        }
    }
}