using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rgbd;

	// Use this for initialization
	void Start () {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if(GameControl.instance.isOver == true)
        {
            rgbd.velocity = Vector2.zero;
        }
	}
}
