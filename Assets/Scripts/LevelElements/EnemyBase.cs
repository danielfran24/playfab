using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour{


    private CurrentPlayerStats player;

    public int damage;
    public float speed;
    public int score;

    public bool jumper;
    public float jumpForce;

    public Rigidbody2D myRb2d;
    private bool canJump = true;


    void Awake() {

        player = FindObjectOfType<CurrentPlayerStats>();

    }


    void Update() {

        if (!jumper) {

            transform.position += Vector3.left * speed * Time.deltaTime;

        }        

    }

    void FixedUpdate() {

        if (jumper && canJump) {

            Jump();

        }

    }


    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            player.GetDamage(damage);

        }if(collision.CompareTag("Mele Attack")) {

            Death(score);

        }

    }

    private void Death(int amount) {

        player.AddScore(amount);

        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Ground")) {

            canJump = true;

        }


    }

    private void Jump() {

        myRb2d.AddForce(Vector2.up * jumpForce);

        canJump = false;

    }


}
