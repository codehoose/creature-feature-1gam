using UnityEngine;

public class GameController : MonoBehaviour
{
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
        // TODO: At some point you'll want to bring this in from prefs or someplace else
        var levelName = @"Testing\larger-map";
        drawBlocks.Draw(levelName);

        var spawnPoint = drawBlocks.PlayerStart;
        spawnPoint.x = (drawBlocks.cellWidth * (spawnPoint.x / 256f)) -8f;
        spawnPoint.y = 0f;

        var copy = Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
        followCam.target = copy.transform;

        var gun = copy.GetComponent<PlayerGun>();
        gun.bulletPrefab = bulletPrefab;
    }
}
