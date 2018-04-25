using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorilla : MonoBehaviour {
    
    public Transform gorillaHidePositon;
    public Transform gorillaDestinationPosition;

    private float gorillaSpeed = 1.0f;
    private Transform gorillaTransform;

	void Start()
	{
        gorillaTransform = this.gameObject.transform;
	}

	void Update()
	{
        if(GameControl.instance.isOver == false)
        {
            gorillaTransform.position = Vector2.MoveTowards(gorillaTransform.position, gorillaHidePositon.position, Time.deltaTime * gorillaSpeed);
        }else if(GameControl.instance.isOver == true)
        {
            gorillaTransform.position = Vector2.MoveTowards(gorillaTransform.position, gorillaDestinationPosition.position - new Vector3(1,0), Time.deltaTime * gorillaSpeed * 5.0f);
        }
	}
}
