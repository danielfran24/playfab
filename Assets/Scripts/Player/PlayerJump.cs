using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour{

    public Rigidbody2D myRigidbody;

    private CurrentPlayerStats player;

    public bool isJump = false;
    public bool canJump = true;

    public float jumpForce = 5.0f;

    public Animator playerAnimator;

    public float cooldown;

    private float time;

    private bool canAttack = true;
    private bool attacking = false;


    public BoxCollider2D swordAttackCollider;
    public BoxCollider2D airAttackCollider;

    void Awake() {

        player = FindObjectOfType<CurrentPlayerStats>();

    }

    void FixedUpdate(){

        if (isJump) {

            isJump = false;
            myRigidbody.velocity = Vector2.up * jumpForce;
            canJump = false;

            playerAnimator.SetBool("canJump", false);

        }



    }

    void Update() {

        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);

        attacking = stateInfo.IsName("Dash-Attack");

        if (!canAttack) {


            time -= Time.deltaTime;
            if (time <= 0) {

                canAttack = true;
                

            }

        }

        if (attacking) {

            
            float playbackTime = stateInfo.normalizedTime;
            
            if(playbackTime >0.33 && playbackTime < 0.66) {

                swordAttackCollider.enabled = true;

            }else {

                swordAttackCollider.enabled = false;

            }


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

            airAttackCollider.enabled = false;
            myRigidbody.gravityScale = 1;

            player.canTakeDamage = true;

            playerAnimator.SetBool("canJump", true);



        }

    }

    public void Dash() {

        if (!canJump) {

            player.canTakeDamage = false;

            airAttackCollider.enabled = true;
            myRigidbody.gravityScale = 90;
            

        }
        else{

            if (canAttack) {

                playerAnimator.SetTrigger("attack");
                
                canAttack = false;

                time = cooldown;

            }

            



        }
        

    }


}
