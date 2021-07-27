using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour{


    
    public Text costText;
    public Text hpText;
    public Text moneyText;

    void Start() { 

        costText.text = "Cost: " + 5 * GameManager.Instance.PlayerData.TotalHP;
        hpText.text = GameManager.Instance.PlayerData.TotalHP.ToString();
        moneyText.text = GameManager.Instance.PlayerData.Money.ToString();
    }


    public void BuyHP() {


        if(GameManager.Instance.PlayerData.Money >= 5 * GameManager.Instance.PlayerData.TotalHP) {

            GameManager.Instance.PlayerData.Money -= 5 * GameManager.Instance.PlayerData.TotalHP;

            GameManager.Instance.PlayerData.TotalHP += 1;

            hpText.text = GameManager.Instance.PlayerData.TotalHP.ToString();
            moneyText.text = GameManager.Instance.PlayerData.Money.ToString();

            costText.text = "Cost: " + 5 * GameManager.Instance.PlayerData.TotalHP;

            PlayfabManager.Instance.SetPlayerData();

        }



    }


}
