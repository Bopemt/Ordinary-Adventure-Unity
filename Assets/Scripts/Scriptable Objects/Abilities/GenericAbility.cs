using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Generic Ability", fileName = ("New Generic Ability"))]
public class GenericAbility : ScriptableObject
{
    public FloatValue energyCost;
    public float duration;

    //public FloatValue playerEnergy;
    public SignalCore energySignal;

    public virtual void Ability(Vector2 playerPosition, Vector2 playerFaceDirection, GenericEnergy playerEnergy, 
        Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {

    }
}
