using UnityEngine;

[CreateAssetMenu(fileName ="Gun", menuName = "Treasure/Gun")]
public class GunScriptableObject : TreasureScriptableObject
{
    public GameObject bulletPrefab;
    public float cooldownPeriod;

    public override void Apply()
    {
        var controller = FindObjectOfType<GameController>();
        if (controller == null)
            return;

        controller.SetBullet(cooldownPeriod, bulletPrefab);
    }
}
