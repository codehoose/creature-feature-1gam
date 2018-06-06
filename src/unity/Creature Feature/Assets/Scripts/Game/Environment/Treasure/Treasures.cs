using UnityEngine;

public class Treasures : MonoBehaviour
{
    public TreasureScriptableObject[] treasures;

    private void Awake()
    {
        var chest = gameObject.GetComponentInChildren<TreasureChest>();
        if (chest == null)
            return;

        chest.treasures = treasures;
    }
}
