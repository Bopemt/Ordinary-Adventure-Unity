using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Dash Ability", fileName = ("New Dash Ability"))]
public class DashAbility : GenericAbility
{
    public float dashForce;

    public override void Ability(Vector2 playerPosition, Vector2 playerFaceDirection, GenericEnergy playerEnergy, 
        Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {
        if(playerEnergy.GetEnergy() >= energyCost.value)
        {
            playerEnergy.Decrease(energyCost.value);
            energySignal.Raise();
        }
        else
        {
            return;
        }
        if (playerRigidbody)
        {
            Vector3 dashVector = playerRigidbody.transform.position + (Vector3)playerFaceDirection.normalized * dashForce;
            playerRigidbody.DOMove(dashVector, duration);
        }
    }
}
