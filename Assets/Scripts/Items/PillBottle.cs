using UnityEngine;

public class PillBottle : MonoBehaviour
{
    public Sprite itemSprite;
    public Sanity sanity;
    public GameObject pillBottleItem; // Reference to this item in the inventory

    private void Start()
    {
        itemSprite = GetComponent<Sprite>();

        // Create new ItemClass object
        ItemClass newItem = new ItemClass("PillBottle", "Consumable", itemSprite);
    }

    private void Update()
    {
        // Check if the player presses Q
        if (Input.GetKey(KeyCode.Q))
        {
            // Check if the pill bottle is in the inventory
            if (InventoryManager.Instance != null &&
                InventoryManager.Instance.HasItem(pillBottleItem)) // Ensure this item is present in the inventory
            {
                // Restore sanity
                sanity.insanity = 10;
                sanity.UpdateInsanitySprite();

                // Remove the pill bottle from the inventory
                InventoryManager.Instance.RemoveItem(pillBottleItem);
                Debug.Log("Pill bottle used and removed from inventory.");
            }
            else
            {
                Debug.Log("No pill bottle in inventory!");
            }
        }
    }
}
