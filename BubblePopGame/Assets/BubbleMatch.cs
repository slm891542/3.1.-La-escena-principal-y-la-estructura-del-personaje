using System.Collections.Generic;
using UnityEngine;

public class BubbleMatch : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private static List<GameObject> matchedBubbles = new List<GameObject>();

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        matchedBubbles.Clear(); // Reiniciar la lista de burbujas coincidentes
        FindMatchingBubbles(transform.position, spriteRenderer.sprite);

        if (matchedBubbles.Count >= 3)
        {
            foreach (GameObject bubble in matchedBubbles)
            {
                Destroy(bubble); // Destruir todas las burbujas del mismo color que estén juntas
            }
        }
    }

    void FindMatchingBubbles(Vector2 position, Sprite targetSprite)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.65f);
        foreach (Collider2D collider in colliders)
        {
            BubbleMatch otherBubble = collider.GetComponent<BubbleMatch>();
            if (otherBubble != null && otherBubble.spriteRenderer.sprite == targetSprite && !matchedBubbles.Contains(collider.gameObject))
            {
                matchedBubbles.Add(collider.gameObject);
                FindMatchingBubbles(collider.transform.position, targetSprite);
            }
        }
    }
}
