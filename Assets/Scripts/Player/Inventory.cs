using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string itemName;
    public ItemType itemType;

    public ItemData(string name, ItemType type)
    {
        itemName = name;
        itemType = type;
    }
}

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();

    public Player player;

    // Add item to inventory
    public void AddItem(ItemClass item)
    {
        items.Add(new ItemData(item.itemName, item.itemType));

        // If the item is a weapon add 1 to the player's health
        if (item.itemType == ItemType.Weapon)
        {
            player.Health += 1;
            Debug.Log($"Player health: {player.Health}");
        }

        Debug.Log($"Item {item.itemName} added to inventory");
    }

    // Use the item from the inventory
    public void UseItem(ItemType type, Player player)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemType == type)
            {
                // Logic for using the item
                if (type == ItemType.Consumable)
                {
                    if (items[i].itemName == "Sanity Pills")
                    {
                        Debug.Log("Using Sanity Pills...");
                        player.RestoreSanity();
                    }
                }

                // Remove item from inventory after use
                items.RemoveAt(i);
                return; // Exit once the item is used
            }
        }

        Debug.Log($"No item of type {type} found in inventory.");
    }
}
