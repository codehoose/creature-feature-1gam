using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {


    public Sprite[] blockImages;

    public void SetInfo(int layer, int sprite)
    {
        GetComponent<SpriteRenderer>().sprite = blockImages[sprite];
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
