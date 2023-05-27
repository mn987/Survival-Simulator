using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AddComponent : MonoBehaviour
{       
    /// <summary>
    /// This class to add component rigibody and navmesh agent with collider when this tranform collider with gameobject.tag "Groud"
    /// this must can be add navmesh agent cause 
    /// "Failed to create agent because it is not close enough to the NavMesh"
    /// </summary>

    protected List<Transform> listMonsters;

    public void Awake() {
        for (int i = 0; i < 3; i++){
            Transform childFolder = transform.GetChild(i);

            foreach (Transform monster in childFolder){
                monster.gameObject.AddComponent<Rigidbody>();
                monster.gameObject.AddComponent<NavMeshAgent>();

                listMonsters.Add(monster);
            }
        }
        
    }

    // private void OnCollisionEnter(Collision other) {
    //     if (other.gameObject.tag == "Ground"){
    //         foreach (Transform monster in listMonsters){
    //             monster.gameObject.AddComponent<NavMeshAgent>();
    //         }
    //     }
    // }
}
