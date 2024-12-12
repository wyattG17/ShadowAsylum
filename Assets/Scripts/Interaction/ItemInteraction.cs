using UnityEngine;

public class ItemInteraction : Interactable
{
    public override void Interact()
    {
        if (IsPlayerInRange())
        {
            // Try to add the item to the inventory
            bool added = InventoryManager.Instance.AddItem(gameObject);

            if (added)
            {
                Destroy(gameObject); // Remove the item from the scene if added successfully
            }
            else
            {
                Debug.Log("Couldn't pick up the item. Inventory is full.");
            }
        }
    }
}
