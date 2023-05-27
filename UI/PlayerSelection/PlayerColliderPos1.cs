using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderPos1 : MonoBehaviour
{
    void OnMouseDown() {
        Debug.Log(gameObject.name);
        
        Transform check = PlayerSelection.instance.pos5.GetChild(0);

        if (check != null){
            check.gameObject.AddComponent<PlayerDestroyObjectPos5>();
            PlayerSelection.instance.InstancePlayer(transform);
        }

    }
}
