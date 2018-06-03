using UnityEngine;

public class TreasureChestLevelManager : MonoBehaviour
{
    GameController gameController;

    [Header("Gun and ammo details")]
    [Tooltip("Bullet prefab")]
    public GameObject bulletPrefab;

    [Tooltip("Fire cooldown period")]
    public float cooldownPeriod = 0.5f;
    
    [Tooltip("The gun icon")]
    public Sprite gunIcon;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public PrizeInfo GetPrizeInfo(TreasureTypes treasures)
    {
        return new PrizeInfo(gunIcon, () => gameController.SetBullet(cooldownPeriod, bulletPrefab));
    }
}
