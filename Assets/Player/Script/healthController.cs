using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maximumHealth;

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged; 
    public GameObject Losepanel;

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0) return;
        if (IsInvincible) return;

        _currentHealth -= damageAmount;

        if (_currentHealth < 0) _currentHealth = 0;

        if (_currentHealth == 0)
        {
            OnDied.Invoke();
            Losepanel.SetActive(true);
        }
        else
        {
            OnDamaged.Invoke();
        }

        OnHealthChanged.Invoke(); 
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealth) return;

        _currentHealth += amountToAdd;

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }

        OnHealthChanged.Invoke();
    }
}