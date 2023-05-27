using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{   
    protected TextMeshPro textScores;

    public Transform folderEnemy;

    //Text follow player
    public Transform player;

    protected float tempNumMonsterDead = 0;

    private void Awake() {
        textScores = transform.GetChild(0).GetChild(1).GetComponent<TextMeshPro>();

    }
    
    private void Update() {
        //Text follow player (no need, just add it in canvas and it always follow camera)
        // transform.position = new Vector3(player.position.x, player.position.y + 0.5f, player.position.z + 2);
        // transform.rotation = player.rotation;

        string vOut = tempNumMonsterDead.ToString();
        // textScores.text = "Scores" + vOut;
        textScores.SetText("Scores: " + vOut);
        foreach (Transform childFolder in folderEnemy)
            {
                foreach (Transform monster in childFolder){
                    if (monster.gameObject.name == "isDead"){
                        monster.gameObject.name = "isDead" + tempNumMonsterDead.ToString();
                        tempNumMonsterDead += 1;
                        // textScores.text = "Scores" + vOut;
                        textScores.SetText("Scores: " + vOut);
                    }
                }
            }
        
    }
}
