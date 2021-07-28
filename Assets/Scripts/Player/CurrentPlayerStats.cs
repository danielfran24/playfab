using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerStats : MonoBehaviour{


    public Animator playerAnimator;

    [Header("Stats")]

    public int currentPlayerHP;

    public int currentPlayerMoney;

    public int currentPlayerScore;

    public bool dead = false;

    public bool canTakeDamage = true;

    public bool damaged = false; 

    [Header("UI References")]

    public Text HPText;

    public Text MoneyText;

    public Text ScoreText;

    public Text finalScoreText;

    public Text finalMaxScoreText;

    void Awake() {

        

    }



    void Start() {

        currentPlayerHP = GameManager.Instance.PlayerData.TotalHP;

        currentPlayerMoney = 0;

        currentPlayerScore = 0;

        HPText.text = "x" + currentPlayerHP.ToString();

        MoneyText.text = currentPlayerMoney.ToString();

        ScoreText.text = "Score: " + currentPlayerScore.ToString();

        //StartCoroutine(AddScoreByTime(1,2f));

    }

    void Update() {

        if (dead) {

            playerAnimator.SetBool("dead", dead);

        }

    }


    public void AddMoney(int amount) {

        currentPlayerMoney += amount;

        MoneyText.text = currentPlayerMoney.ToString();

    }

    public void AddScore(int amount) {

        currentPlayerScore += amount;

        ScoreText.text = "Score: " + currentPlayerScore.ToString();

    }



    public void GetDamage(int amount) {

        if (canTakeDamage) {

            currentPlayerHP -= amount;

            if(currentPlayerHP < 0) {

                currentPlayerHP = 0;

            }

            HPText.text = "x" + currentPlayerHP.ToString();

            playerAnimator.SetTrigger("damaged");

            if (currentPlayerHP <= 0) {

                PlayerDeath();

            }else {

                StartDamageAnimation();

            }


        }



    }

    private void StartDamageAnimation() {

        if (!damaged) {

            damaged = true;
            canTakeDamage = false;

        }


    }

    public void StopDamageAnimation() {

        damaged = false;
        canTakeDamage = true;

    }


    public void HealPlayer(int amount) {

        currentPlayerHP += amount;

        if (currentPlayerHP > GameManager.Instance.PlayerData.TotalHP) {

            currentPlayerHP = GameManager.Instance.PlayerData.TotalHP;

        }

        HPText.text = "x" + currentPlayerHP.ToString();

    }

    /*
    private IEnumerator AddScoreByTime(int amount,float delayTime) {

        yield return new WaitForSeconds(delayTime);

        currentPlayerScore += amount;

        ScoreText.text = "Score: " + currentPlayerScore.ToString();

        

    }
*/



    public void PlayerDeath() {

        if (!dead) {

            Debug.Log(GameManager.Instance.PlayerData.Money);


            GameManager.Instance.PlayerData.Money += currentPlayerMoney;

            dead = true;

            


            if (currentPlayerScore > GameManager.Instance.PlayerData.MaxScore) {

                GameManager.Instance.PlayerData.MaxScore = currentPlayerScore;

            }

            

            finalScoreText.text = "Score: " + currentPlayerScore;
            finalMaxScoreText.text = "Max score: " + GameManager.Instance.PlayerData.MaxScore;

            GameManager.Instance.SaveProgress();

        }

        

    }


}
