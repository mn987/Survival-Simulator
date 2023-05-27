using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{   
    public static MonsterHealth instance;

    //==Setup máu cho các quái==
    //Current health
    public float health;
    //Max health
    public float maxHealthBoss = 100;
    public float maxHealthCreep = 10;

    //Số lượng thư mục quái
    public float numChildObject = 3;

    //Vị trí tên quái vật trong danh sách tên
    public int index;
    //Danh sách tên các con vật
    public List<string> listNameMonsters;
    //Danh sách máu của các con vật
    public List<float> listHealthMonsters;

    public GameObject effectDead;
    //Destroy 
    protected float timeDestroyObject = 0;
    protected float timeDestroyEffect = 3;

    private void Awake() {
        
        MonsterHealth.instance = this;
        
        for (int i = 0; i < numChildObject; i++){

            Transform childObject = transform.GetChild(i);

            //Setup máu 

            if (childObject.gameObject.name == "==Boss=="){
                this.health = maxHealthBoss;
            }
            else {
                this.health = maxHealthCreep;
            }


            foreach (Transform monster in childObject){
                //Thêm tên các con vật vào một danh sách cũng như máu của chúng
                this.listNameMonsters.Add(monster.gameObject.name);
                this.listHealthMonsters.Add(health);                
            }

            //Set collider to each transform monster

            if (childObject.gameObject.name == "==Boss=="){
                foreach (Transform monster in childObject){
                    GameObject collissionMonster = monster.gameObject;
                    //Thêm collision cho mỗi đối tượng con
                    collissionMonster.AddComponent(typeof(BoxCollider));
                    //Set size collider monster
                    collissionMonster.GetComponent<BoxCollider>().size = new Vector3(3, 5, 3);                    
                }
            }
            else {
                foreach (Transform monster in childObject){
                    GameObject collissionMonster = monster.gameObject;
                    //Thêm collision cho mỗi đối tượng con
                    collissionMonster.AddComponent(typeof(BoxCollider));
                    //Set size collider monster
                    collissionMonster.GetComponent<BoxCollider>().size = new Vector3(10, 10, 2);
                }
            }
        }
        
        
    }

    void Start()
    {

    }
    
    //Danh sách máu của các con vật/ vị trí của con vật đó/ lượng damage nhận vào
    public void TakeDamage(string name, int amount){

        this.index = this.listNameMonsters.IndexOf(name);
        this.listHealthMonsters[index] -= amount;
        //Check isDead
        if (listHealthMonsters[index] <= 0){
            Debug.Log(listNameMonsters[index] + " isDead");

            //Gắn tên quái thành isDead
            //Lượt qua tất cả thư mục chứa tên quái
            for (int i = 0; i < numChildObject; i++){
                Transform childObject = transform.GetChild(i);
                foreach(Transform monster in childObject){
                    GameObject nameMonster = monster.gameObject;
                    if (nameMonster.name == listNameMonsters[index]){
                        nameMonster.name = "isDead";
                        Vector3 tempPosition = nameMonster.transform.position;
                        // Destroy(nameMonster, timeDestroyObject);
                        nameMonster.SetActive(false);
                        
                        Instantiate(effectDead, tempPosition, Quaternion.identity);
                        // Destroy(effect, timeDestroyEffect);
                    }
                }
            }

        }
    }
}
