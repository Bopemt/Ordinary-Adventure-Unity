using UnityEngine;

[CreateAssetMenu(menuName = "Values/Item Value", fileName = "New Item Value")]
public class ItemValue : ScriptableObject
{
    public InventoryItem defaultValue;

    public InventoryItem value;

    private void OnEnable()
    {
        value = defaultValue;
    }

    public void SetValue(InventoryItem newValue)
    {
        value = newValue;
    }
}
