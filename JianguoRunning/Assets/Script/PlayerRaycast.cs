using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour {

    RaycastHit2D hit2D;
    RaycastHit2D hit2D2;
    LayerMask obstacle;
    LayerMask obstacle2;

    Vector2 playerFrontStartPoint;
    Vector2 PlayerFrontEndPoint;


	void Start()
	{
        obstacle = LayerMask.GetMask("obstacle");
        obstacle2 = LayerMask.GetMask("obstacle2");
	}

	void Update()
    {
        playerFrontStartPoint = new Vector2(transform.position.x, transform.position.y - 0.5f);
        PlayerFrontEndPoint = new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f);
        hit2D = Physics2D.Linecast(playerFrontStartPoint,PlayerFrontEndPoint, obstacle);
        hit2D2 = Physics2D.Linecast(transform.position, new Vector2(transform.position.x + 0.5f, transform.position.y - 1.7f), obstacle2);
       
        if(hit2D.transform != null || hit2D2.transform != null)
        {
            GameControl.instance.isOver = true;
            //GameControl.instance.anim.SetTrigger("Die");
            GameControl.instance.PlayerDie();
        }
	}

	private void OnDrawGizmos()
	{
        Gizmos.DrawLine(playerFrontStartPoint, PlayerFrontEndPoint);
	}
}
