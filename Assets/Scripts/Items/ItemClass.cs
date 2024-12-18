using UnityEngine;

public class ItemClass : MonoBehaviour
{
    public string itemName;
    public ItemType itemType;

    public ItemType GetItemType()
    {
        return itemType;
    }
}

public enum ItemType
{
    Consumable,
    Weapon
    // Add more item types here
}
