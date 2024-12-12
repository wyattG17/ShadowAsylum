using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    public Sprite itemSprite;

    private void Start()
    {
        itemSprite = GetComponent<Sprite>();

        // Create new ItemClass object
        ItemClass newItem = new ItemClass("Syringe", "Weapon", itemSprite);
    }
}
