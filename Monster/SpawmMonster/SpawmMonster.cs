using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmMonster : MonoBehaviour
{       
    public static SpawmMonster instance;

    public Transform player;

    //Các loại quái
    public Transform boss;
    public Transform creep;
    //Số lượng quái cần spawn
    public float num;
    public float numSpawnBoss = 2;
    public float numSpawnCreep = 5;

    //Số lượng thư mục quái (hiện tại theo thứ tự là ==Boss==/ ==CanAttack==/ ==CantAttack==)
    public float numParent = 3;
    
    void Awake() {
        SpawmMonster.instance = this;

        for (int i = 0; i < numParent; i++){
            Transform objectChild = transform.GetChild(i);
            if (objectChild.gameObject.name == "==Boss=="){
            //Set quantity num monster spawn
                num = numSpawnBoss;
                //Khởi tạo quái (đối tượng quái/ số lượng quái/vị trí thư mục quái khởi tọa)
                quantitySpawnMonster(boss, num, objectChild);
                SetPosMonster(objectChild);
            }
            else {
            //Set quantity num monster spawn
                num = numSpawnCreep;
                //Khởi tạo quái (đối tượng quái/ số lượng quái/vị trí thư mục quái khởi tọa)
                quantitySpawnMonster(creep, num, objectChild);
                SetPosMonster(objectChild);
            }
        }
    }

    public void quantitySpawnMonster(Transform monster, float num, Transform objectChild){
        for (int i = 0; i < num ; i++){
            Instantiate(monster, objectChild);
        }
    }

    //Số thứ tự quái được spawn ra sau tên
    public float tempNum = 0;
    //Set pos monster have been spawn
    void SetPosMonster(Transform childObject){
        foreach (Transform mon in childObject){

            //Spamn quai xung quanh nhưng chỉ áp dụng trên mặt phẳng, trên terrain sẽ bị lỗi
            // mon.position = GetRandomPosAroundPlayer(player);

            //Spamn quái vào một điểm để khác phục lỗi add navmeshagent
            mon.position = transform.position;

            mon.gameObject.name = mon.gameObject.name + "_" + tempNum;
            tempNum += 1;
        }
    }

    Vector3 GetRandomPosAroundPlayer(Transform player){
        //distance player with monster
        float dis = 30;

        Vector3 rdiUS = randomPosInsideSphere();

        Vector3 pos = new Vector3(rdiUS.x * player.position.x * dis, 0.5f, rdiUS.z * player.position.z * dis);

        return pos;
    }

    Vector3 randomPosInsideSphere(){
        //Sử dụng hàm insideUnitSphere để trả về một vector ngẫu nhiên trong một khối cầu
        //Bán kính hình cầu
        float radius = 2;
        Vector3 rdiUS = Random.insideUnitSphere * radius;

        // //distance player with monster
        // float dis = Vector3.Distance(player.position, rdiUS);
        
        
        // if (dis > 50){
            
        // } //do nothing
        // else {
        //     rdiUS = randomPosInsideSphere();
        // }
        return rdiUS;
    }
}
