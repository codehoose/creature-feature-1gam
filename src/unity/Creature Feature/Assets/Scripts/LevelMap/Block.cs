using UnityEngine;

public class Block : MonoBehaviour
{
    public Sprite[] blockImages;

    public void SetInfo(int layer, int sprite, bool disableCollision = false)
    {
        var spr = GetComponent<SpriteRenderer>();
        try
        {
            spr.sprite = blockImages[sprite];
        }
        catch (System.IndexOutOfRangeException e)
        {
            print(e);
        }

        spr.sortingLayerID = layer;
        name = spr.sprite.name;
        if (disableCollision)
        {
            //gameObject.layer = LayerMask.NameToLayer("Background");
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
