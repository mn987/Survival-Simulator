using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtl : MonoBehaviour
{   
    public static PlayerCtl instance;
    public Rigidbody rb;
    public Transform Objtransform;
    //Tốc độ di chuyển của nhân vật
    public float speed = 3f;
    public float jumpSpeed = 6f;

    //Check isloading when u speed up
    //if true speed will not changer even u press button shift
    public bool isloading;

    //Tạo một biến boolean để check đk nhân vật đang nhảy hay không
    public bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCtl.instance = this;
        rb = Objtransform.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Di chuyển nhân vật
        playerMoving();

        //Nhảy
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false){
            rb.velocity = Vector3.up * jumpSpeed;
            isJumping = true;
        }

    }

    //Check Dk với mặt đất
    /*
        collision => collision
        trigger => collider
    */
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ground"){
            isJumping = false;
        }
    }

    private void playerMoving(){

        //Nhấn shift để chạy nhanh hơn
        if (Input.GetKeyDown(KeyCode.LeftShift) && isloading == false){
            speed = 10f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 3f;
        }

        float moveByZ = InputManager.instance.vertical * speed * Time.deltaTime;
        float moveByX = InputManager.instance.horizontal * speed * Time.deltaTime;

        transform.Translate(moveByX, 0, moveByZ);
    }
}
