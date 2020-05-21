using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Projectile Ability", fileName = ("New Projectile Ability"))]
public class ProjectileAbility : GenericAbility
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject bowObject;

    public override void Ability(Vector2 playerPosition, Vector2 playerFaceDirection, GenericEnergy playerEnergy,
        Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {
        float facingRotation = Mathf.Atan2(playerFaceDirection.y, playerFaceDirection.x) * Mathf.Rad2Deg;
        if (playerEnergy.GetEnergy() >= energyCost.value)
        {
            playerEnergy.Decrease(energyCost.value);
            energySignal.Raise();

            GameObject newProjectile = Instantiate(projectile, playerPosition, Quaternion.Euler(0f, 0f, facingRotation - 45));
            Projectile temp = newProjectile.GetComponent<Projectile>();
            if (temp)
            {
                temp.Launch(playerFaceDirection);
            }
        }
        else
        {
            return;
        }
        GameObject bow = Instantiate(bowObject, playerPosition + playerFaceDirection / 2, Quaternion.Euler(0f, 0f, facingRotation - 45));
    }
}
