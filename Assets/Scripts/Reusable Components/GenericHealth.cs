using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    public FloatValue health;
    public float currentHealth;

    public virtual void Start()
    {
        currentHealth = health.defaultValue;
    }

    public virtual void Heal(float amountToHeal)
    {
        currentHealth += amountToHeal;
        if(currentHealth > health.defaultValue)
        {
            currentHealth = health.defaultValue;
        }
    }

    public virtual void Damage(float amountToDamage)
    {
        currentHealth -= amountToDamage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void SetHealth(float amount)
    {
        currentHealth = amount;
    }
    
    public virtual void FullHeal()
    {
        currentHealth = health.defaultValue;
    }

    public virtual void InstantDeath()
    {
        currentHealth = 0;
    }
}
