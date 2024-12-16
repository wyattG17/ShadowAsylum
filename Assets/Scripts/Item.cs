using UnityEngine;

public enum ItemType { Weapon, Consumable }

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]

public abstract class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public int value;  // For consumables, value could be health amount. Weapons may use it for something else.

    public abstract void UseItem(PlayerItemInteraction playerItemInteraction);  // Abstract method to be implemented by derived classes.
}
