using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSlowObject : MonoBehaviour {
    
    private Rigidbody2D rgbd;

    public float scrollSpeed = -2.0f;
    // Use this for initialization
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.instance.isOver == true)
        {
            rgbd.velocity = Vector2.zero;
        }
    }
}
