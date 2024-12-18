using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    // Variables and Classes
    public float walkSpeed = 5f;
    public float sprintSpeed = 9f;
    public int Health = 1;

    public Sanity sanity;
    public Inventory inventory;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get value of horizontal and vertical input
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        // Create a movement vector from the movements
        Vector2 movement = new Vector2(xInput, yInput);

        // Normalize movement vector and apply walk speed
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        // Move sprite using RigidBody2D Component
        if (Input.GetKey(KeyCode.LeftShift)) // Check if leftShift is held down
        {
            rb.velocity = movement * sprintSpeed;
        }
        else
        {
            rb.velocity = movement * walkSpeed;
        }

        // Consumable usage
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Search for Sanity Pills in the inventory
            foreach (var item in inventory.items)
            {
                if (item.itemType == ItemType.Consumable && item.itemName == "Sanity Pills")
                {
                    if (sanity.insanity == 10)
                    {
                        return;
                    }

                    inventory.UseItem(ItemType.Consumable, this);
                    break;
                }
            }
        }
    }

    public void RestoreSanity()
    {
        sanity.insanity = 10;
        sanity.UpdateInsanitySprite();
    }
}
