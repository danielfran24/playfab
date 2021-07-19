using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour{

    public static PlayerStatsManager instance = null;

    void Awake() {
    
        if(instance == null) {

            instance = this;

        }else if(instance != this) {

            Destroy(gameObject);

        }

        DontDestroyOnLoad(gameObject);

    }


    public int totalPlayerMoney;

    public int maxPlayerHP;

    public int maxPlayerScore;



    


}
