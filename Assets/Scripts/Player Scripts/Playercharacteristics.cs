using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercharacteristics : MonoBehaviour
{
    [Header("Characteristics")]
    public PlayerFloatValue playerHealth;
    public PlayerFloatValue playerDamage;
    public PlayerFloatValue playerMoveSpeed;
    public PlayerFloatValue playerAttackSpeed;

    [Header("Energy Stuff")]
    public FloatValue energyIncrease;
    public FloatValue energyIncreaseDelay;
    public FloatValue energyCost;
}
