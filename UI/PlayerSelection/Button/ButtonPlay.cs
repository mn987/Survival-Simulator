using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{   
    protected string sceneName = "Scene01";

    public GameObject MenuPlayer;

    private void Start() {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        Debug.Log("Button play has been clicked");

        DontDestroyOnLoad(MenuPlayer);
        SceneManager.LoadScene(sceneName);
    }
}
