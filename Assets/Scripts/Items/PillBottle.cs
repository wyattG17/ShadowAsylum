using UnityEngine;

public class PillBottle : MonoBehaviour
{
    public Sprite itemSprite;

    private void Start()
    {
        itemSprite = GetComponent<Sprite>();

        // Create new ItemClass object
        ItemClass newItem = new ItemClass("PillBottle", "Consumable", itemSprite);
    }
}
