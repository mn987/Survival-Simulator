using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Monster
// {   
//     public string nameMonster;

//     public Monster(string nameMonster){
//         this.nameMonster = nameMonster;
//     }
// }

public class Test : MonoBehaviour
{   
    // public Monster monster;


    public List<Transform> listMonsters;


    public float speed = 3f;

    void Awake() {
        Transform monsters = transform.GetChild(1);

        foreach (Transform monster in monsters){
            monster.gameObject.AddComponent<Rigidbody>();
            monster.gameObject.AddComponent<BoxCollider>();
            listMonsters.Add(monster);


        }
    }

    void Update() {

        foreach (Transform monster in listMonsters){
            Rigidbody rigiMonster = monster.GetComponent<Rigidbody>();
            // monster.Translate(new Vector3(1,0,1) * Time.deltaTime * speed);
            rigiMonster.AddForce(new Vector3(1,0,1) * 2.5f);
            
        }
    }
}
