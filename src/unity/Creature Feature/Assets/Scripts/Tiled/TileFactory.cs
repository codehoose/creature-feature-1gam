using UnityEngine;
using System.Linq;

public static class TileFactory
{
    const string Background = "Background";
    const string Platforms = "Platforms";
    const string PlayerStart = "PlayerStart";
    const string Spawn = "Spawn";

    public static LevelTiles Create(string filename)
    {
        var textAsset = Resources.Load<TextAsset>(filename);
        if (textAsset == null)
            return null;

        var json = textAsset.text;
        var tiledFile = JsonUtility.FromJson<TiledFile>(json);

        return CreateFrom(tiledFile);
    }

    private static LevelTiles CreateFrom(TiledFile tiledFile)
    {
        var level = new LevelTiles(tiledFile.width, 
                                   tiledFile.height, 
                                   tiledFile.tilewidth, 
                                   tiledFile.tileheight);

        var background = tiledFile.layers.FirstOrDefault(l => l.name.Equals(Background));
        var platforms = tiledFile.layers.FirstOrDefault(l => l.name.Equals(Platforms));

        var playerStartLayer = tiledFile.layers.FirstOrDefault(l => l.name.Equals(PlayerStart));
        if (!string.IsNullOrEmpty(playerStartLayer.name))
        {
            var playerSpawn = playerStartLayer.objects.FirstOrDefault(l => l.name.Equals(Spawn));
            if (!string.IsNullOrEmpty(playerSpawn.name))
            {
                level.SetPlayerStart(playerSpawn.x, playerSpawn.y);
            }
        }

        level.SetLayers(background, platforms);

        return level;
    }
}
