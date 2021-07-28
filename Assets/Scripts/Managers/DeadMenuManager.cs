using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMenuManager : MonoBehaviour{

    private CurrentPlayerStats player;

    public GameObject deathMenu;


    void Awake() {

        player = FindObjectOfType<CurrentPlayerStats>();

    }

    public void StopGettingDamage() {

        player.StopDamageAnimation();

    }


    public void FinishGame() {


        Time.timeScale = 0;

        ShowDeathMenu();


    }


    public void ShowDeathMenu() {

        deathMenu.SetActive(true);

    }


}
