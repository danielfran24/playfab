using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour{


    private CurrentPlayerStats player;

    public int damage;
    public float speed;
    public int score;

    void Awake() {

        player = FindObjectOfType<CurrentPlayerStats>();

    }


    void Update() {

        transform.position += Vector3.left * speed * Time.deltaTime;

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


}
