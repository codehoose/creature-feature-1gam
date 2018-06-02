using UnityEngine;

public class TestLevelLoader : MonoBehaviour
{
    Vector3 pos;

    public string levelName;

    public GameObject prefab;

	// Use this for initialization
	void Start ()
    {
        var level = TileFactory.Create(levelName);

        float starty = level.Height / 2;
        float startx = -level.Width / 2;

        var data = level.Background;
        for (int y = 0; y < level.Height; y++)
        {
            for (int x = 0; x < level.Width; x++)
            {
                int idx = data[x, y];
                var copy = Instantiate(prefab);
                copy.transform.parent = transform;
                copy.transform.position = Vector3.zero;
                copy.transform.localPosition = new Vector3(startx + x, starty - y, 0);
                copy.GetComponent<Block>().SetInfo(0, idx);
            }
        }

        data = level.Platforms;
        for (int y = 0; y < level.Height; y++)
        {
            for (int x = 0; x < level.Width; x++)
            {
                int idx = data[x, y];
                if (idx == 0) continue;
                var copy = Instantiate(prefab);
                copy.transform.parent = transform;
                copy.transform.position = Vector3.zero;
                copy.transform.localPosition = new Vector3(startx + x, starty - y, 0);
                copy.GetComponent<Block>().SetInfo(0, idx);
            }
        }
    }

    void Update()
    {
        //if (Input.GetAxis("Horizontal") < -0.5f)
        //{
        float speed = 2f;
            pos = new Vector3(75, 0, 0) * Time.deltaTime * -Input.GetAxis("Horizontal") * speed;

        //}
        //else if ( > 0.5f)
        //{
        //    pos = pos + new Vector3(2, 0, 0) * Time.deltaTime;
        //}
    }

    // Update is called once per frame
    void LateUpdate () {

        // Hmmm... camera?!

        float speed = 2f;
        transform.position = Vector3.Lerp(transform.position, transform.position + pos, Time.deltaTime);
        
        

    }
}
