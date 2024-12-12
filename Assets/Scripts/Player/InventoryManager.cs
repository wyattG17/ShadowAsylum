using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton for easy access

    public int maxSlots = 3; // Maximum number of items
    private List<GameObject> inventory = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool AddItem(GameObject item)
    {
        if (inventory.Count < maxSlots)
        {
            inventory.Add(item);
            Debug.Log($"Item {item.name} added to inventory.");
            return true;
        }
        else
        {
            Debug.Log("Inventory is full!");
            return false;
        }
    }

    public void RemoveItem(GameObject item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log($"Item {item.name} removed from inventory.");
        }
    }

    public void PrintInventory() // For debugging purposes
    {
        Debug.Log("Current Inventory:");
        foreach (GameObject item in inventory)
        {
            Debug.Log(item.name);
        }
    }
}
