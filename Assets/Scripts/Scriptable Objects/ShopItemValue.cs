using UnityEngine;

[CreateAssetMenu(menuName = "Values/Shop Item Value", fileName = "New Shop Item Value")]
public class ShopItemValue : ScriptableObject
{
    public ShopItem defaultValue;

    public ShopItem value;

    private void OnEnable()
    {
        value = defaultValue;
    }
}
