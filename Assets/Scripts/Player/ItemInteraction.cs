using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Inventory playerInventory;  // Reference to the player's inventory
    private ItemClass itemInRange;         // Reference to the item currently in range
    private bool canInteract;         // Flag to check if the player can interact with the item

    private void Update()
    {
        // If the player is in range of an item and presses the 'E' key, try to pick it up
        if (canInteract && Input.GetKeyDown(KeyCode.E) && itemInRange != null)
        {
            TryPickupItem();
        }
    }

    // Called when another collider enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to an item
        ItemClass item = other.GetComponent<ItemClass>();
        if (item != null)
        {
            itemInRange = item;  // Store the item in range
            canInteract = true;   // Enable interaction
        }
    }

    // Called when another collider exits the trigger area
    private void OnTriggerExit2D(Collider2D other)
    {
        // If the player leaves the range of the item, disable interaction
        if (itemInRange != null && other.gameObject == itemInRange.gameObject)
        {
            canInteract = false;  // Disable interaction
            itemInRange = null;   // Clear the reference to the item
        }
    }

    // Attempt to pick up the item
    private void TryPickupItem()
    {
        if (itemInRange != null)
        {
            playerInventory.AddItem(itemInRange);  // Add the item as ItemData
            Destroy(itemInRange.gameObject);       // Destroy the item after pickup
            itemInRange = null;                    // Clear the reference
        }
    }
}
