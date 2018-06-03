using UnityEngine;

public class TestLevelLoader : MonoBehaviour
{
 //   Vector3 pos;

 //   public string levelName;

 //   public GameObject prefab;

 //   public float cellWidth = 16f;
 //   public float cellHeight = 16f;

 //   public float screenWidthInBlocks = 16;
 //   public float screenHeightInBlocks = 9;

	//void Start ()
 //   {
 //       var level = TileFactory.Create(levelName);

 //       float starty = level.Height / 2;
 //       float startx = -screenWidthInBlocks / 2;

 //       float cw = level.TileWidth / cellWidth;
 //       float ch = level.TileHeight / cellHeight;

 //       DrawBlocks(level.Background, SortingLayer.NameToID("Background"), level.Height, level.Width, cw, ch, startx, starty);
 //       DrawBlocks(level.Platforms, SortingLayer.NameToID("Platforms"), level.Height, level.Width, cw, ch, startx, starty);
 //   }

 //   private void DrawBlocks(int[,] data, 
 //                           int sortingLayer, 
 //                           int height, 
 //                           int width, 
 //                           float cw, 
 //                           float ch,
 //                           float startx,
 //                           float starty)
 //   {
 //       for (int y = 0; y < height; y++)
 //       {
 //           for (int x = 0; x < width; x++)
 //           {
 //               int idx = data[x, y];
 //               if (idx == 0) continue;
 //               var copy = Instantiate(prefab);
 //               copy.transform.parent = transform;
 //               copy.transform.position = Vector3.zero;
 //               copy.transform.localPosition = new Vector3(startx + x * cw, starty - y * ch, 0);
 //               copy.GetComponent<Block>().SetInfo(sortingLayer, idx);
 //           }
 //       }
 //   }

 //   void Update()
 //   {
 //       //if (Input.GetAxis("Horizontal") < -0.5f)
 //       //{
 //       float speed = 2f;
 //           pos = new Vector3(75, 0, 0) * Time.deltaTime * -Input.GetAxis("Horizontal") * speed;

 //       //}
 //       //else if ( > 0.5f)
 //       //{
 //       //    pos = pos + new Vector3(2, 0, 0) * Time.deltaTime;
 //       //}
 //   }

 //   // Update is called once per frame
 //   void LateUpdate () {

 //       // Hmmm... camera?!

 //       float speed = 2f;
 //       transform.position = Vector3.Lerp(transform.position, transform.position + pos, Time.deltaTime);
        
 //       if (transform.position.x < 0)
 //       {
 //           transform.position = Vector3.zero;
 //       }
 //   }
}
