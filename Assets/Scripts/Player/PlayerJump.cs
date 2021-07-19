using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour{

    public Rigidbody2D myRigidbody;

    public bool isJump = false;
    public bool canJump = true;

    public float jumpForce = 5.0f;

    public Animator playerAnimator;

    void FixedUpdate(){

        if (isJump) {

            isJump = false;
            myRigidbody.velocity = Vector2.up * jumpForce;
            canJump = false;

            playerAnimator.SetBool("canJump", false);

        }



    }


    public void ClickJump() {

        if (canJump) {
            isJump = true;
        }
        

    }


    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Ground")) {

            canJump = true;

            myRigidbody.gravityScale = 1;

            playerAnimator.SetBool("canJump", true);



        }

    }

    public void Dash() {

        if (!canJump) {

            myRigidbody.gravityScale = 90;

        }
        

    }



}
