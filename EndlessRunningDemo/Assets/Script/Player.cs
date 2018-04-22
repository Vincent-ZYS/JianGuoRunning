using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private float timer = 0f;
    private float timeSinceLastJump = 0f;
    private float jumpRate = 1.0f;
    private bool isApproach = false;

    public float addForce = 200.0f;
    public Animator playerAnimator;
    public Rigidbody2D PlayerRb2D;

	void Start () {

	}
	
	void Update () {
        
        if(isApproach){
            timeSinceLastJump += Time.deltaTime;
        }

        timer += Time.deltaTime;

        if( GameControl.instance.isOver == false)
        {
            if(timer >= 4)
            {
                GameControl.instance.BirdScore();
                timer = 0f;
            }
            if(GameControl.instance.Volume >= 0.2f && isApproach == false)
            {
                isApproach = true;
                PlayerRb2D.AddForce(new Vector2(0, addForce));
                playerAnimator.SetTrigger("Jump");
                //StartCoroutine(WaitForSecond());
            }
            if(timeSinceLastJump > jumpRate)
            {
                isApproach = false;
                timeSinceLastJump = 0;
            }

            //if(Input.GetMouseButtonDown(0))
            //{
            //    PlayerRb2D.velocity = Vector2.zero;
            //    PlayerRb2D.AddForce(new Vector2(0, addForce));
            //    playerAnimator.SetTrigger("Jump");
            //}
        }
	}

    //IEnumerator WaitForSecond()
    //{
    //    yield return new WaitForSeconds(1);
    //    isApproach = false;
    //}

 //   private void OnCollisionEnter2D(Collision2D other)
 //   {
 //       float otherY = other.transform.position.y;
 //       if (transform.position.y < otherY || transform.position.y < other.collider.transform.position.y 
 //           || other.collider.tag == "sky" ) //(other.gameObject.tag != "plane")
 //       {
 //           rgbd.velocity = Vector2.zero;
 //           GameControl.instance.isOver = true;
 //           playerAnimator.SetTrigger("Die");
 //           //这里之所以使用单例模式，是基于面向对象思想，若将游戏结束写在这个脚本上，则会破坏flappy bird这个对象的面向对象结构
 //           GameControl.instance.BirdDie();
 //       }
 //       else if (transform.position.y >= otherY)
 //       {
 //           //Debug.Log("Plane");
 //           return;
 //       }
	//}
}
