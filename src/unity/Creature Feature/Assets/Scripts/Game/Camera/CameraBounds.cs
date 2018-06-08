using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraBounds : MonoBehaviour
{
    void Awake()
    {
        var grid = FindObjectOfType<Grid>();
        if (grid == null)
            return;

        float minX = float.MaxValue;
        float minY = float.MaxValue;
        float maxX = float.MinValue;
        float maxY = float.MinValue;

        var tilemaps = grid.GetComponentsInChildren<Tilemap>();
        foreach(var tilemap in tilemaps)
        {
            var bounds = tilemap.localBounds;

            if (bounds.min.x < minX)
                minX = bounds.min.x;

            if (bounds.min.y < minY)
                minY = bounds.min.y;

            if (bounds.max.x > maxX)
                maxX = bounds.max.x;

            if (bounds.max.y > maxY)
                maxY = bounds.max.y;
        }

        var followCam = GetComponent<FollowTargetCamera>();
        followCam.bounds = new Rect(minX + 8, minY + 5, maxX - 8, maxY * 2);
        //print("Min = " + minX + "," + minY + ", Max = " + maxX + ", " + maxY);
    }
}
