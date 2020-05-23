using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private FloatValue playerLevel;
    [SerializeField] private FloatValue playerExp;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private SignalCore levelSignal;
    [SerializeField] private GameObject levelUpEffect;
    public float expToNextLvl;
    [SerializeField] private float expIncrease;

    public void Start()
    {
        levelSignal.Raise();
        expToNextLvl += expIncrease * (playerLevel.value - 1);
    }

    public void AddExperience()
    {
        if(playerExp.value >= expToNextLvl)
        {
            if (playerLevel.value <= 10)
            {
                playerLevel.value++;
                playerExp.value -= expToNextLvl;
                expToNextLvl += expIncrease /*+ 10 * (playerLevel.value - 1)*/;
                //expToNextLvl += expIncrease;
                //expToNextLvl = expIncrease;
                levelSignal.Raise();
                //weaponSignal.Raise();
                //healthSignal.Raise();
                playerHealth.FullHeal();
                GameObject effect = Instantiate(levelUpEffect, transform.parent);
                Destroy(effect, 1f);
            }
        }
    }
}
