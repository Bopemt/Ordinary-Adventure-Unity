using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : GenericEnergy
{
    [SerializeField] private SignalCore energySignal;

    public override void Update()
    {
        base.Update();
        energySignal.Raise();
    }

    public override void Decrease(float amountToDecrease)
    {
        base.Decrease(amountToDecrease);
        energySignal.Raise();
    }
}
