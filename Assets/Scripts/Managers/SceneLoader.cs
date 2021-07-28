using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{
 



    public void ChangeScene(string scene) {


        SceneManager.LoadScene(scene);

        Time.timeScale = 1;

        //Provisional, no nos mates si esto sigue aquí Dani 
        

    }





}
