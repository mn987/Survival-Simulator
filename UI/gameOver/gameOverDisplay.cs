using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverDisplay : MonoBehaviour
{   
    public GameObject player;

    //Lấy hai đói tượng canvas và image để khởi tạo biến con cho nó
    public GameObject canvas, imageGameOver, imageRed;

    public GameObject buttonRestartGame;

    protected GameObject gameover;

    private void Awake() {
        
        //Khởi tạo các đối tượng trong canvas
        Instantiate(imageGameOver, canvas.transform);
        Instantiate(imageRed, canvas.transform);


        //Thêm box collider cho button để xác nhận khi có nút bấm vào
        GameObject button = Instantiate(buttonRestartGame, canvas.transform);
        BoxCollider boxCollider = button.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(200, 55, 1);
        //Đồng thời thêm script để nó phát hiện có va cha cũng như thêm event khi được click vào
        button.AddComponent<ClickButtonGameOver>();
        
        // Disable image
        foreach (Transform temp in transform){
            gameover = temp.gameObject;

            if (gameover.name != canvas.gameObject.name){
                gameover.SetActive(false);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //if player is dead, show text
        if (player.name == "==Player== isDead"){
            // gameObject.SetActive(true);
            setScreenGameover();
            //Tắt khóa chuột
            Cursor.lockState = CursorLockMode.None;  
        }
    }

    void setScreenGameover(){
        foreach (Transform transform in transform){
            transform.gameObject.SetActive(true);
        }
    }
}   
