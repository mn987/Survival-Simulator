using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//https://viblo.asia/p/bai-toan-tim-duong-di-trong-unity-Qpmlenx75rd

//thread.sleep
//waitforsecond

public class MonsterMovementRandomly : MonoBehaviour
{   
    protected NavMeshAgent agent;
    //presentPosition
    public Vector3 prePos;
    //newPosition
    public Vector3 newPos;

    //Danh sách các transform con 
    public Transform[] childTransforms;
    //Danh sách các Vector3
    public List<Vector3> listPos;
    //move speed creep
    public float moveSpeedCreep = 5;

    
    //Lấy ra đối tượng người chơi 
    public Transform player;

    private void Awake() {
        childTransforms = GetComponentsInChildren<Transform>();

        foreach (Transform childTransform in childTransforms){

            GameObject childGameObject = childTransform.gameObject;

            Rigidbody rigidbody = childGameObject.AddComponent<Rigidbody>();
        }
    }

    void Start() 
    {   
        //Lấy danh sách tất cả các chi tiết của gameObject con:
        childTransforms = GetComponentsInChildren<Transform>();

        //Lặp qua danh sách chi tiết và thêm NavMeshAgent vào các gameObject
        foreach (Transform childTransform in childTransforms){
            //Đưa đối tượng từ Transform => gameObject
            GameObject childGameObject = childTransform.gameObject;
            
            //Thêm component NavMeshAgent cho các object con
            

            NavMeshAgent navMeshAgent = childGameObject.GetComponent<NavMeshAgent>();
            
            if (navMeshAgent == null){
                navMeshAgent = childGameObject.AddComponent<NavMeshAgent>();
            }
            
            listPos.Add(new Vector3(0,0,0));
        }

        

        //Lấy ra các vị trí ngẫu nhiên và luôn tự động cập nhật sau 5s
        randomPosition();

    }

    void Update()
    {   
        //Gọi Hàm di chuyển các object con
        moveObjectRandomly(childTransforms, listPos);
        // agent.destination = newPos;
    }

    void randomPosition(){
        for (int i = 0; i < childTransforms.Length; i++){
            float xPos = Random.Range(-50, 50);
            float zPos = Random.Range(-50, 50);
            newPos = new Vector3(xPos, 1, zPos);
            listPos[i] = newPos;
        }
        // Debug.Log(listPos);
        //Gọi lại hàm này sau 5s
        Invoke("randomPosition", 5f);
        // StartCoroutine(randomPosition(childTransforms, 1f));
    }

    void moveObjectRandomly(Transform[] childTransforms, List<Vector3> listPos){

        for (int i = 0; i < childTransforms.Length; i++){

            //Mặc định đối tượng sẽ đứng lên
            //Setup góc quay cho quái
            if (childTransforms[i].gameObject.name != "==Attack=="){
                childTransforms[i].eulerAngles = new Vector3(childTransforms[i].eulerAngles.x + -90, childTransforms[i].eulerAngles.y, childTransforms[i].eulerAngles.z);
                
            }
            NavMeshAgent agent = childTransforms[i].GetComponent<NavMeshAgent>();
            

            //vị trí tiếp theo nó di chuyển sẽ bằng vị trí hiện tại + một vector ngẫu nhiên 
            prePos = childTransforms[i].position + listPos[i];
            // if (player.position < childTransforms[i].position + new Vector3(5,0,5) && player.position < childTransforms[i].position - new Vector3(5,0,5))
            //Distance player with monster
            float dis = Vector3.Distance(player.position, childTransforms[i].position);
            
            //Tốc độ di chuyển của quái
            agent.speed = moveSpeedCreep;

            //Khoá vị trí cũng như góc xoay của quái khi quái chết
            // if (childTransforms[i].gameObject.name == "isDead"){
            if (childTransforms[i].gameObject.name.Contains("isDead") || childTransforms[i].gameObject == null){

                agent.destination = childTransforms[i].position;
                
                childTransforms[i].eulerAngles = new Vector3(childTransforms[i].eulerAngles.x + 90, childTransforms[i].eulerAngles.y, childTransforms[i].eulerAngles.z);

                // childTransforms[i].gameObject.AddComponent<Rigidbody>();
                // childTransforms[i].gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                // childTransforms[i].gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
            // else if (childTransforms[i].gameObject.name != "isDead" && dis < 15)
            else if ( !(childTransforms[i].gameObject.name.Contains("isDead")) || childTransforms[i].gameObject == null && dis < 15)
            {   
                
                agent.destination = player.position;
                
            }
            else
            {   
                agent.destination = prePos;
                
            }
            
        }
    }

}
