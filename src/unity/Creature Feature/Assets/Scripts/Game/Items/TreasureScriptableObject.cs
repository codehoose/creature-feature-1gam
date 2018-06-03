using UnityEngine;

public abstract class TreasureScriptableObject : ScriptableObject
{
    public Sprite icon;

    public abstract void Apply();
}
