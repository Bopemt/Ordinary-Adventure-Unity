using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeaponSlot : MonoBehaviour
{
    [SerializeField] private Image weaponImage;
    [SerializeField] private ItemValue currentWeapon;

    private void OnEnable()
    {
        if (!currentWeapon.value)
        {
            weaponImage.enabled = false;
        }
        else
        {
            UpdateImage();
        }
    }

    public void UpdateImage()
    {
        weaponImage.enabled = true;
        weaponImage.sprite = currentWeapon.value.mySprite;
    }
}
