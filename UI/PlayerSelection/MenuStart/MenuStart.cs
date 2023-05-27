using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{   

    [SerializeField] private Transform pos_s;

    private void Awake() {

        pos_s = transform.GetChild(1);

        //Setactive false những thứ không cần thiết
        GameObject MenuPlayer = GameObject.FindGameObjectWithTag("==MenuPlayer==");
        GameObject uiInterface = GameObject.FindGameObjectWithTag("==UI==");

        // MenuPlayer.SetActive(false);
        uiInterface.transform.GetChild(0).gameObject.SetActive(false);
        uiInterface.transform.GetChild(1).gameObject.SetActive(false);

        for (int i = 0; i <= 5; i++)
        {
            Transform model = MenuPlayer.transform.GetChild(i);
            Transform pos = pos_s.GetChild(i);

            model.position = pos.position;
        }

    }
}

