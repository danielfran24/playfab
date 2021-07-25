using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour{

    private CurrentPlayerStats player;

    public int HPRecover;

    void Awake() {

        player = FindObjectOfType<CurrentPlayerStats>();

    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            player.HealPlayer(HPRecover);

            Destroy(gameObject);


        }

    }




}
