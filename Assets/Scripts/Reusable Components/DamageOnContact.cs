using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : GenericDamage
{
    [SerializeField] private string otherTag;
    [SerializeField] private int damageAmount;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag))
        {
            GenericHealth temp = other.gameObject.GetComponent<GenericHealth>();
            if (temp)
            {
                ApplyDamage(temp, damageAmount);
            }
        }
    }
}
