using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI moveSpeedText;
    [SerializeField] private FloatValue playerLevel;
    [SerializeField] private PlayerFloatValue playerHealth;
    [SerializeField] private PlayerFloatValue playerDamage;
    [SerializeField] private PlayerFloatValue playerMS;

    private void OnEnable()
    {
        levelText.text = "Level: " + playerLevel.value;
        healthText.text = "Health: 20+" + playerLevel.value * playerHealth.characteristicPerLevel;
        damageText.text = "Damage: +" + playerLevel.value * playerDamage.characteristicPerLevel;
        moveSpeedText.text = "Move Speed: 3+" + playerLevel.value * playerMS.characteristicPerLevel;
    }
}
