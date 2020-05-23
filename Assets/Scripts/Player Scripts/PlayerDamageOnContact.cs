using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageOnContact : GenericDamage
{
    [SerializeField] private string otherTag;
    [SerializeField] private PlayerFloatValue damageAmount;
    private float damage;

    private void OnEnable()
    {
        damage = damageAmount.value;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag))
        {
            GenericHealth temp = other.gameObject.GetComponent<GenericHealth>();
            if (temp)
            {
                ApplyDamage(temp, damage);
            }
        }
    }
}
