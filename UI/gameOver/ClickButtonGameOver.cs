using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickButtonGameOver : MonoBehaviour
{       
    //Để check xem ng chơi đã click chưa tránh tình trạng click quá nhiều
    public bool hasClick;

    protected string sceneName = "Scene01";

    protected void OnMouseDown() {
        // Debug.Log("ButtonRestart has been clicked");
        ReloadScene();
        hasClick = true;
    }

    protected void ReloadScene(){
        if (hasClick == false){
            SceneManager.LoadScene(sceneName);
        }
    }
}
