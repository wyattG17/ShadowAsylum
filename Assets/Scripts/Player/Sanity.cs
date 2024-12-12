using UnityEngine;

public class Sanity : MonoBehaviour
{
    // If you are wondering where this script is located, it's in the meter sprite in the camera.
    // Making your first Unity game is rough...

    public int insanity = 10;
    public int drainAmount = 1;
    public int drainTime = 15;

    public Sprite[] insanitySprites; // Array to store spliced sprites
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("SanityDrain", drainTime, drainTime);
        UpdateInsanitySprite();
    }

    private void SanityDrain()
    {
        insanity -= drainAmount;
        UpdateInsanitySprite();

        if (insanity < 0)
        {
            // Player reaches zero sanity left
            return;
        }
    }

    private void UpdateInsanitySprite()
    {
        if (insanity >= 0)
        {
            spriteRenderer.sprite = insanitySprites[insanity];
        }
    }
}
