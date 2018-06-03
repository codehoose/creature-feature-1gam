using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject _player;

    [Tooltip("The main player's prefab to spawn when the level starts")]
    public GameObject playerPrefab;

    [Tooltip("The main player's bullet prefab")]
    public GameObject bulletPrefab;

    [Tooltip("The object that draws the map")]
    public DrawBlocks drawBlocks;

    [Tooltip("The camera that follows the player around")]
    public FollowTargetCamera followCam; // TODO: SET UP PLAYER / TARGET etc.
    
	void Start ()
    {
        var levelSpawnPoint = GameObject.Find("SpawnPoint");

        var spawnPoint = Vector2.zero;

        if (levelSpawnPoint == null)
        {
            // TODO: At some point you'll want to bring this in from prefs or someplace else
            var levelName = @"Testing\larger-map";
            drawBlocks.Draw(levelName);

            spawnPoint = drawBlocks.PlayerStart;
            spawnPoint.x = (drawBlocks.cellWidth * (spawnPoint.x / 256f)) - 8f;
            spawnPoint.y = 0f;
        }
        else
        {
            spawnPoint = levelSpawnPoint.transform.position;
        }

        _player = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
        followCam.target = _player.transform;
    }

    internal void SetBullet(float cooldownPeriod, GameObject bulletPrefab)
    {
        var gun = _player.GetComponent<PlayerGun>();
        gun.bulletPrefab = bulletPrefab;
        gun.cooldownPeriod = cooldownPeriod;
    }
}
