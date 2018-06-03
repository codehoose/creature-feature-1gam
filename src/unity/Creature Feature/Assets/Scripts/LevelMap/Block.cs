using UnityEngine;

public class Block : MonoBehaviour
{
    public void SetInfo(int layer, Sprite sprite, bool disableCollision = false)
    {
        var spr = GetComponent<SpriteRenderer>();

        spr.sprite = sprite;
        spr.sortingLayerID = layer;
        name = spr.sprite.name;

        if (disableCollision)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
