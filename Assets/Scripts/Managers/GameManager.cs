using ClasePlayfab;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class GameManager : Singleton<GameManager>{

    public static event Action OnserverLogin;

    #region Data

    public string GameVersion;
    public EconomyModel ServerEconomy;
    public PlayerModel PlayerData;

    #endregion

    void Awake() {

        OnserverLogin += LoadServerData;

        PlayerData.Money = 10;
        PlayerData.TotalHP = 2;
        PlayerData.MaxScore = 100;

    }

    void OnDestroy() {

        OnserverLogin -= LoadServerData;

    }


    void Start() {

        ServerLogin();

    }

    #region LOGIN

    private void ServerLogin() {

        PlayfabManager.Instance.Login(OnLoginSuccess, OnLoginFailed);

    }


    private void OnLoginSuccess(LoginResult loginResult) {

        Debug.Log("User Login: " + loginResult.PlayFabId);


    }

    private void OnLoginFailed(PlayFabError error){

        Debug.LogError("Login failed: " + error.ErrorMessage);

    }


    #endregion


    #region Load Server Data

    public void LoadServerData() {

        PlayfabManager.Instance.GetTitleData(titleData => {

            LoadGameSetup(titleData.Data);


        },
        error => {

            Debug.LogError("Get Title Data failed: " + error.ErrorMessage);

        });

    }

    private void LoadGameSetup(Dictionary<string, string> data) {

        SetPlayfabVersion(data["ClientVersion"]);
        SetPlayfabEconomyModel(data["EconomySetup"]);

    }

    private void SetPlayfabVersion(string version) {

        GameVersion = version;

    }

    private void SetPlayfabEconomyModel(string economyJson) {

        JsonUtility.FromJsonOverwrite(economyJson, ServerEconomy);

    }


    #endregion

}
