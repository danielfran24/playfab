using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour{

    public int value;

    private CurrentPlayerStats playerStats;

    void Awake() {

        playerStats = FindObjectOfType<CurrentPlayerStats>();

    }


    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            playerStats.AddMoney(value);

            Destroy(gameObject);

        }

    }


}
