using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] slots = new Item[3];  // Maximum of 3 slots

    // Add an item to the first available slot in the inventory
    public bool AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)  // Find the first empty slot
            {
                slots[i] = item;  // Add item to the slot
                Debug.Log($"{item.itemName} added to inventory.");
                return true;  // Successfully added the item
            }
        }
        Debug.Log("Inventory is full.");
        return false;  // Inventory is full, item couldn't be added
    }

    // Use an item from the inventory by slot index (1, 2, or 3)
    public void UseItem(int slotIndex)
    {
        if (slots[slotIndex] != null)
        {
            slots[slotIndex].UseItem(GetComponent<PlayerItemInteraction>());
            slots[slotIndex] = null;  // Remove item after use
        }
        else
        {
            Debug.Log("No item in this slot.");
        }
    }
}
