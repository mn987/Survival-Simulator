using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    //Boss mặc định luôn rượt theo player nhưng sẽ chậm hơn rất nhiều so với các loài quái khác
    //Máu trâu và nhiều hơn
    //Có thể tấn công từ xa
    protected NavMeshAgent agent;

    //Lấy model boss vào
    public Transform boss;

    public Transform[] childTransforms;

    //
    public float bossMoveSpeed = 3;
    //Check boss is dead
    public bool isDead;


    //Lấy đối tượng người chơi vào
    public Transform player;

    private void Awake() {
        
    }

    private void Start() {

        foreach (Transform childTransform in transform){
            GameObject childGameObject = childTransform.gameObject;

            NavMeshAgent navMeshAgent = childGameObject.GetComponent<NavMeshAgent>();

            if (navMeshAgent == null){
                navMeshAgent = childGameObject.AddComponent<NavMeshAgent>();
            }
        }
    }

    void FixedUpdate() {
        bossMovement();   
    }

    void bossMovement(){
        foreach (Transform eachBoss in transform){
            agent = eachBoss.gameObject.GetComponent<NavMeshAgent>();

            agent.speed = bossMoveSpeed;

            // if (eachBoss.gameObject.name == "isDead"){
            if (eachBoss.gameObject.name.Contains("isDead") || eachBoss.gameObject == null){
                agent.destination = eachBoss.position;
                
                eachBoss.eulerAngles = new Vector3(eachBoss.eulerAngles.x + 90, eachBoss.eulerAngles.y, eachBoss.eulerAngles.z);

            }
            else {
                agent.destination = player.position;
            }
        }
    }
}
