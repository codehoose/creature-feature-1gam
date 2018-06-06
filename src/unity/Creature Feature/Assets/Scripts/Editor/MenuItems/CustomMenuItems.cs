using UnityEngine;
using UnityEditor;

public static class CustomMenuItems
{
    [MenuItem("EnemyMob", menuItem = "GameObject/Creature Feature/Patrol Mob")]
    public static void CreateEnemyMob()
    {
        var gameObject = new GameObject("EnemyMob");
        gameObject.AddComponent<PatrolMob>();
        gameObject.AddComponent<Enemy>();
        gameObject.AddComponent<AudioSource>();
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        Selection.activeObject = gameObject;
    }
}
