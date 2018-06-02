public class LevelTiles 
{
    int _width;
    int _height;

    int[,] _background;
    int[,] _platforms;

    //public int[,] GetBackground(int x, int y)
    //{

    //}

    public int Width { get { return _width; } }

    public int Height { get { return _height; } }

    public int[,] Background { get { return _background; } }

    public int[,] Platforms { get { return _platforms; } }

    public LevelTiles(int width, int height)
    {
        _width = width;
        _height = height;
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
}
