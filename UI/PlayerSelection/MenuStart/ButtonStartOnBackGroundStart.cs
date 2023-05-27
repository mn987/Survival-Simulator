using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStartOnBackGroundStart : MonoBehaviour
{   
    public Transform ui_Object;
    public GameObject menuPlayer;

    private void Start() {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {   
        Debug.Log("Button has been clicked");
        //Get BackGroundSelection and set active true
        ui_Object.GetChild(0).gameObject.SetActive(true);

        //Get MenuSelection set active true
        menuPlayer.SetActive(true);

        //after done, setactive false current gameobject
        ui_Object.GetChild(1).gameObject.SetActive(false);



    }
}
