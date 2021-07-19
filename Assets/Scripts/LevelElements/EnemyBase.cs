using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour{


    private CurrentPlayerStats player;

    public int damage;

    void Awake() {

        player = FindObjectOfType<CurrentPlayerStats>();

    }


    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            player.GetDamage(damage);

        }

    }


}
