using UnityEngine;

public class DrawBlocks : MonoBehaviour
{
    private Sprite[] _currentSpriteSet;

    public GameObject prefab;

    public float cellWidth = 16f;
    public float cellHeight = 16f;

    public float screenWidthInBlocks = 16;
    public float screenHeightInBlocks = 9;

    public Vector2 PlayerStart { get; private set; }

    public Sprite[] frankenstein;

    public void Draw(string levelName)
    {
        // TODO: Choose the level art!
        _currentSpriteSet = frankenstein;

        var level = TileFactory.Create(levelName);
        PlayerStart = level.PlayerSpawn;

        float cw = level.TileWidth / cellWidth;
        float ch = level.TileHeight / cellHeight;

        float starty = screenHeightInBlocks / 2;
        float startx = -screenWidthInBlocks / 2;

        //BlockDraw(level.Background, SortingLayer.NameToID("Background"), level.Height, level.Width, cw, ch, startx, starty, true);
        BlockDraw(level.Platforms, SortingLayer.NameToID("Platforms"), level.Height, level.Width, cw, ch, startx, starty);
    }

    private void BlockDraw(int[,] data,
                           int sortingLayer,
                           int height,
                           int width,
                           float cw,
                           float ch,
                           float startx,
                           float starty,
                           bool backgroundLayer = false)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int idx = data[x, y];
                if (idx == 0) continue;
                var copy = Instantiate(prefab);

                var sprite = _currentSpriteSet[idx];

                copy.transform.parent = transform;
                copy.transform.position = Vector3.zero;
                copy.transform.localPosition = new Vector3(startx + x * cw, starty - y * ch, 0);
                copy.GetComponent<Block>().SetInfo(sortingLayer, sprite, backgroundLayer);
            }
        }
    }
}
