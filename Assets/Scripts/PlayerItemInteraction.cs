using UnityEngine;

public class PlayerItemInteraction : MonoBehaviour
{
    public float pickupRange = 2f; // Adjust as needed
    private Inventory inventory;
    private Sanity sanity;

    void Start()
    {
        inventory = GetComponent<Inventory>(); // Assuming the player has an inventory script
        sanity = GetComponent<Sanity>();
    }

    void Update()
    {
        // Check for item pickup
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Detect all colliders within the pickup range using Physics2D.OverlapCircle
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, pickupRange);

            foreach (var hitCollider in hitColliders)
            {
                ItemPickup itemPickup = hitCollider.GetComponent<ItemPickup>();
                if (itemPickup != null)
                {
                    if (inventory.AddItem(itemPickup.item))
                    {
                        Destroy(itemPickup.gameObject);
                        break;
                    }
                }
            }
        }

        // Use items with keys 1, 2, 3
        if (Input.GetKeyDown(KeyCode.Alpha1)) inventory.UseItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) inventory.UseItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) inventory.UseItem(2);
    }

    public void RefillSanity()
    {
        sanity.insanity = 10;
        sanity.UpdateInsanitySprite();
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize pickup range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
