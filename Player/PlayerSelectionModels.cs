using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionModels : MonoBehaviour
{
    [SerializeField] private GameObject modelSelect;

    private void Start() {
        //Get model character từ pos 5 trong dontdestroy
        modelSelect = GameObject.FindGameObjectWithTag("CharacterSelected");
        modelSelect = modelSelect.transform.GetChild(0).gameObject;
        
        //Khởi tạo nhân vật trong ==Player==
        Instantiate(modelSelect, transform);
        //Tắt model nhân vật hiện tại
        transform.GetChild(1).gameObject.SetActive(false);
        //Tắt gameobject trong dontdestroy
        GameObject menuPlayer = GameObject.Find("==MenuPlayer==");
        menuPlayer.SetActive(false);

        //Gán đè model nhân vật trong biến modelSelect
        modelSelect = transform.GetChild(3).gameObject;

        //Set scale cho nhân vật
        modelSelect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
        modelSelect.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        modelSelect.transform.Rotate(new Vector3(0, 180, 0));
        // Debug.Log(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z));

        // if (modelSelect != null){
        //     Debug.Log("Model has found");
        // }

    }   

}
