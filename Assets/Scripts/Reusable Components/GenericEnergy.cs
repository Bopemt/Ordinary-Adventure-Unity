using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnergy : MonoBehaviour
{
    [SerializeField] private FloatValue energy;
    [SerializeField] protected float passiveIncrease;
    [SerializeField] protected float increaseDelay;
    protected float increaseDelaySeconds;

    private void Start()
    {
        increaseDelaySeconds = increaseDelay;
    }

    public virtual void Update()
    {
        if (increaseDelaySeconds <= 0)
        {
            if (Time.deltaTime > 0.00002f)
            {
                PassiveIncrease(passiveIncrease);
            }
        }
        else
        {
            increaseDelaySeconds -= Time.deltaTime;
        }
    }

    public virtual void PassiveIncrease(float amountToIncrease)
    {
        if(energy.value < energy.defaultValue)
        {
            energy.value += amountToIncrease;
            if (energy.value > energy.defaultValue)
            {
                energy.value = energy.defaultValue;
            }
        }
    }

    public virtual void FullIncreaseEnergy()
    {
        energy.value = energy.defaultValue;
    }

    public virtual void Decrease(float amountToDecrease)
    {
        if (energy.value >= amountToDecrease)
        {
            energy.value -= amountToDecrease;
        }
        increaseDelaySeconds = increaseDelay;
    }

    public float GetEnergy()
    {
        return energy.value;
    }
}
