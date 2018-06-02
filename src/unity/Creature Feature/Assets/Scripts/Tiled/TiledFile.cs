using System;

[Serializable]
public struct TiledFile
{
    public int height;
    public int width;
    public bool infinite;
    public int nextobjectid;
    public string orientation;
    public string renderorder;
    public string tiledversion;
    public int tileheight;
    public int tilewidth;
    public string type;
    public int version;

    public Tileset[] tilesets;
    public Layer[] layers;
}

[Serializable]
public struct Tileset
{
    public int firstgid;
    public string source;
}

[Serializable]
public struct Layer
{
    public int height;
    public int width;
    public string name;
    public string type;
    public int[] data;
}
