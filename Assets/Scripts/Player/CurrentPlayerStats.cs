﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerStats : MonoBehaviour{


    

    private PlayerStatsManager statsManager;

    [Header("Stats")]

    public int currentPlayerHP;

    public int currentPlayerMoney;

    public int currentPlayerScore;


    [Header("UI References")]

    public Text HPText;

    public Text MoneyText;

    public Text ScoreText;

    void Awake() {

        statsManager = FindObjectOfType<PlayerStatsManager>();

    }



    void Start() {

        currentPlayerHP = statsManager.maxPlayerHP;

        currentPlayerMoney = 0;

        currentPlayerScore = 0;

        HPText.text = "x" + currentPlayerHP.ToString();

        MoneyText.text = currentPlayerMoney.ToString();

        ScoreText.text = "Score: " + currentPlayerScore.ToString();

        StartCoroutine(AddScoreByTime(1,2f));

    }

    public void AddMoney(int amount) {

        currentPlayerMoney += amount;

        MoneyText.text = currentPlayerMoney.ToString();

    }


    public void GetDamage(int amount) {

        currentPlayerHP -= amount;

        HPText.text = "x" + currentPlayerHP.ToString();

        if (currentPlayerHP <= 0) {

            PlayerDeath();

        }

    }

    public void HealPlayer(int amount) {

        currentPlayerHP -= amount;

        if (currentPlayerHP > statsManager.maxPlayerHP) {

            currentPlayerHP = statsManager.maxPlayerHP;

        }

        HPText.text = "x" + currentPlayerHP.ToString();

    }

    private IEnumerator AddScoreByTime(int amount,float delayTime) {

        yield return new WaitForSeconds(delayTime);

        currentPlayerScore += amount;

        ScoreText.text = "Score: " + currentPlayerScore.ToString();

        

    }




    public void PlayerDeath() {

        statsManager.totalPlayerMoney += currentPlayerMoney;

        if (currentPlayerScore > statsManager.maxPlayerScore) {

            statsManager.maxPlayerScore = currentPlayerScore;

        }

        Time.timeScale = 0;


    }


}
