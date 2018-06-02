using UnityEngine;
using System.Linq;

public static class TileFactory
{
    const string Background = "Background";
    const string Platforms = "Platforms";

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
        var level = new LevelTiles(tiledFile.width, tiledFile.height);

        var background = tiledFile.layers.FirstOrDefault(l => l.name.Equals(Background));
        var platforms = tiledFile.layers.FirstOrDefault(l => l.name.Equals(Platforms));

        level.SetLayers(background, platforms);

        return level;
    }
}
