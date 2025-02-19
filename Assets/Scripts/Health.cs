using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 5;
    private int _currentHealth;

    [SerializeField]
    private UnityEvent _onDie;
    public void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if ( _currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _onDie?.Invoke();
    }
}
