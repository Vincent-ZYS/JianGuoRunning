using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorilla : MonoBehaviour {

    public Animator gorillaAnimator;
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
            gorillaTransform.position = Vector2.MoveTowards(gorillaTransform.position, gorillaDestinationPosition.position - new Vector3(1, -0.5f), Time.deltaTime * gorillaSpeed * 5.0f);
            if(Vector2.Distance(transform.position,gorillaDestinationPosition.position) <= 2.0f)
            {
                gorillaAnimator.SetTrigger("Grab");
            }
        }
	}
}
