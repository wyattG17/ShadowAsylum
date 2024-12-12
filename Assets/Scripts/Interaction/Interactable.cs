using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float radius = 0.8f;
    private bool isPlayerInRange = false;

    private void Start()
    {
        // Make the circle collider match the radius of the wire gizmo
        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        if (collider == null)
        { 
            collider = gameObject.AddComponent<CircleCollider2D>();
        }

        collider.radius = radius;
        collider.isTrigger = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Make sure the player has the "Player" tag
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            // Player has entered the pickup range
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Player has left the pickup range
        }
    }

    public bool IsPlayerInRange()
    {
        return isPlayerInRange;
    }

    public abstract void Interact();
}
