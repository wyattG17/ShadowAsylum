using UnityEngine;

[System.Serializable]
public class ItemClass
{
    public string itemName; // Name
    public string itemType; // Weapon, Consumable
    public Sprite itemSprite; // Icon

    public ItemClass(string name, string type, Sprite icon)
    {
        itemName = name;
        itemType = type;
        itemSprite = icon;
    }
}