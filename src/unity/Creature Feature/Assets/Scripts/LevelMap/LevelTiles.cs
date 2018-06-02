using UnityEngine;

public class LevelTiles 
{
    int _width;
    int _height;
    int _tileWidth;
    int _tileHeight;

    int[,] _background;
    int[,] _platforms;

    public int Width { get { return _width; } }

    public int Height { get { return _height; } }

    public int TileWidth { get { return _tileWidth; } }

    public int TileHeight { get { return _tileHeight; } }

    public int[,] Background { get { return _background; } }

    public int[,] Platforms { get { return _platforms; } }

    public Vector2 PlayerSpawn { get; private set; }

    public LevelTiles(int width, int height, int tileWidth, int tileHeight)
    {
        _width = width;
        _height = height;
        _tileWidth = tileWidth;
        _tileHeight = tileHeight;
    }

    internal void SetLayers(Layer background, Layer platforms)
    {
        _background = new int[_width, _height];
        _platforms = new int[_width, _height];

        Fill(_background, background);
        Fill(_platforms, platforms);
    }

    private void Fill(int[,] platforms, Layer data)
    {
        int idx = 0;

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x< _width; x++)
            {
                platforms[x, y] = data.data[idx++];
            }
        }
    }

    internal void SetPlayerStart(int x, int y)
    {
        PlayerSpawn = new Vector2(x, y);
    }
}
