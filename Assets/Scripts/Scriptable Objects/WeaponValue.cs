using UnityEngine;

[CreateAssetMenu(menuName = "Values/Weapon Value", fileName = "New Weapon Value")]
public class WeaponValue : ScriptableObject
{
    public InventoryItem defaultValue;

    public InventoryItem value;

    private void OnEnable()
    {
        value = defaultValue;
    }
}
