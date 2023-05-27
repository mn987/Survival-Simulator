using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{       
    public static PlayerSelection instance;

    //Sau khi xác nhận được nhân vật thì gán nó vào pos 5
    public Transform pos5;

    private void Awake() {
        PlayerSelection.instance = this;


    }

    private void Update() {
        float tempNum = 0.1f;
        pos5.eulerAngles = new Vector3(pos5.eulerAngles.x, pos5.eulerAngles.y + tempNum, pos5.eulerAngles.z);
    }

    public void InstancePlayer(Transform player){
        Transform Player = Instantiate(player, pos5);
        Player.position = pos5.position;
        player.rotation = Quaternion.identity;
        Player.localScale = new Vector3(2,2,2);
    }

}
