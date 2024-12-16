using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    public override void UseItem(PlayerItemInteraction playerItemInteraction)
    {
        // Consumable effect, e.g., restoring sanity
        Debug.Log($"Used {itemName}, restored sanity!");
        playerItemInteraction.RefillSanity();
    }
}
