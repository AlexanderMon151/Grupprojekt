using UnityEngine;
using UnityEngine.Events;
public class HealthChangeEvent : UnityEvent<int> 
{ 

}
public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthChangeEvent healthChangeEvent;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthChangeEvent?.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle death logic here
        Debug.Log("Character died.");
    }
}
