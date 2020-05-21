using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GenericDamage : MonoBehaviour
{
    public void ApplyDamage(GenericHealth otherHealth, float damageToGive)
    {
        if (otherHealth)
        {
            otherHealth.Damage(damageToGive);
        }
    }
}
