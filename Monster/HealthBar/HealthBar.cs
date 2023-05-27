using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{   
    public static HealthBar instance;
    
    // Lấy ra đối tượng cam để các thanh máu luôn hướng vào phía cam của người chơi
    public Transform player;

    //Đối tượng để tạo ra các thanh máu
    // public Transform enemy;
    //Lấy gameobject thanh máu vào
    public GameObject healthBar;
    //Lấy thư mục parent
    public Transform folderEnemy;
    //Lấy ra các thư mục con
    protected Transform childObject;
    //Lấy thư mục để chứa thanh máu lúc khởi tạo
    public Transform folderHealthBar;

    //Lấy ra độ dài danh sách transform monster
    public int lenMonsters;

    //Đưa các đối tượng vào một danh sách để cập nhật vị trí đối tượng liên tục sau đó đưa vào danh sách các vị trí của đối tượng
    public List<Transform> listTransformMonsters;
    //Đưa vào vị trí của đối tượng nhắm tới
    public List<Vector3> listPosMonsters;
    //Lấy ra các đối tượng là thanh máu để cật nhật vị trí theo các con vật
    public List<Transform> listHealthBars;

    //Lấy ra compoment image trong gameobject healthbar
    protected Image image;
    //List image
    public List<Image> listImage;

    //Phần hướng thanh máu vào player (distance)
    //Ở đây có một lỗi khi thanh máu lại gần quá player vị trí trục y sẽ bị tụt xuống đất nên tính khoảng cách nó để thanh máu luôn giữ khoảng cách với player
    public float dis;

    //Số lượng thư mục quái
    public float numChildObject = 3;


    public float tempNum;

    protected float numBoss;

    public void Awake() {

        HealthBar.instance = this;

        for (int i = 0; i < numChildObject; i++){
            Transform childObject = transform.GetChild(i);
            
            //Đầu tiên lấy ra các vị trí ban đầu của các con vật
            foreach (Transform monster in childObject){
            
                listPosMonsters.Add(monster.position);
                //Lấy ra chiều dài danh sách các con vật
                lenMonsters +=1 ;

                listTransformMonsters.Add(monster);
            }
        }
        
        //Khởi tạo các thanh máu cho các loại quái vào một thư mục folderHealthBar
        for (int y = 0; y < lenMonsters; y++){
            Instantiate(healthBar, folderHealthBar);
        }

        //Thêm các ảnh vào một list và setup độ dài thanh máu dựa trên quái vật
        //vd Boss thì thanh máu sẽ dài hơn các loại quái còn lại

        //Lấy ra số lượng của các loại quái khác nhau để điều chỉnh độ dài thanh máu dựa trên các loại quái khác nhau
        numBoss = SpawmMonster.instance.numSpawnBoss;
        // numBoss = 2;

        foreach (Transform hpBar in folderHealthBar){
            if (tempNum < numBoss){
                RectTransform imageScale = hpBar.GetChild(0).GetComponent<RectTransform>();
                imageScale.localScale = new Vector3(0.1f, 0.02f, 0);
            }

            Image image = hpBar.GetChild(0).GetChild(0).GetComponent<Image>();
            
            listImage.Add(image);

            tempNum += 1;
        }



        
        //Sau khi khởi tạo các thanh máu thì thêm vào một danh sách để cật nhật vị trí theo các con vật
        foreach (Transform _healthBar in folderHealthBar){
            listHealthBars.Add(_healthBar);
        }

        //Lấy ra đối tượng
        // Debug.Log(transform.GetChild(0).GetChild(0).GetChild(0).gameObject.name);

        tempNum = 0;
    }

    private void Start() {

    }
    
    void Update() {

        //Cập nhập vị trí của thanh máu cho quái
        for (int i = 0; i < lenMonsters; i++){
            // numBoss = SpawmMonster.instance.numSpawnBoss;
            if (i < numBoss){
                listHealthBars[i].position = new Vector3(listTransformMonsters[i].position.x, listTransformMonsters[i].position.y, listTransformMonsters[i].position.z);
            }
            else{
                listHealthBars[i].position = new Vector3(listTransformMonsters[i].position.x, listTransformMonsters[i].position.y - 2.5f, listTransformMonsters[i].position.z);
            }

            //Lấy khoảng cách
            float dis = Vector3.Distance(player.position, listHealthBars[i].position);
            if (dis > 7){
            // Hướng health bar vào cam của player
                listHealthBars[i].LookAt(player.position);
            }
            
        }
    }

    public void UpdateHealthBar(Image im, float currentHp, float maxHp){
        im.fillAmount = currentHp / maxHp;
    }
}
