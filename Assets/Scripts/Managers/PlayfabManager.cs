using ClasePlayfab;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlayfabManager : Singleton<PlayfabManager> {


    void Start() {



       // SetPlayerData();

    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            GetPlayerData();

           

        }

    }

    #region LOGIN

    public void Login(Action<LoginResult> onSucces, Action<PlayFabError> onFail) {

        var request = new LoginWithCustomIDRequest {


            CreateAccount = true,
            CustomId = SystemInfo.deviceUniqueIdentifier

        };

        PlayFabClientAPI.LoginWithCustomID(request, onSucces, onFail);


    }

    public void OnLogin() {

        
    }


    #endregion

    #region PlayerData

    public void GetPlayerData() {


        var request = new GetUserDataRequest() {


            
            
        };

        PlayFabClientAPI.GetUserData(request, (result) => {
            if (result.Data == null) {

                Debug.Log("HHHHEEEEYYY");

            }else {

                GameManager.Instance.PlayerData = PlayerModel.LoadPlayerData(result.Data);
                Debug.Log("Dineros: " + GameManager.Instance.PlayerData.Money);

            }
            
        },
        (error) => {

            Debug.LogError("Error getting user data: " + error.GenerateErrorReport());
            
        });

        

    }

    #endregion


    #region TITLE DATA

    public void GetTitleData(Action<GetTitleDataResult> onSuccess, Action<PlayFabError> onError) {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), onSuccess, onError);
    }

    #endregion


    #region PlayerData

    public void SetPlayerData() {


        PlayerModel player = GameManager.Instance.PlayerData;

        var request = new UpdateUserDataRequest() {

            Data = new Dictionary<string, string>() {

                { "Money", player.Money.ToString()},
                { "TotalHP", player.TotalHP.ToString()},
                { "MaxScore", player.MaxScore.ToString()}


            },
        };

        PlayFabClientAPI.UpdateUserData(request, (result) => {

            Debug.Log("Successfully updated user data!");

        }, (error) => {

            Debug.LogError("Error updating user data: " + error.GenerateErrorReport());

        });

    }

    #endregion

}
