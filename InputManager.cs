using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public Transform player;

    //Chiều dọc 
    public float vertical = 0;
    //Chiều ngang 
    public float horizontal = 0;

    //Chiều ngang chuột
    public float mouseX;
    //Chiều dọc chuột
    public float mouseY;

    //phím chỉnh góc nhìn player

    private void Awake() {
        InputManager.instance = this;
    }

    private void Update() {
        this.GetInputMovement();
        this.GetInputMouseAxis();
    }

    protected void GetInputMovement(){
        this.vertical = Input.GetAxis("Vertical");
        this.horizontal = Input.GetAxis("Horizontal");
    }

    protected void GetInputMouseAxis(){
        this.mouseX = Input.GetAxis("Mouse X");
        this.mouseY = Input.GetAxis("Mouse Y");
    }
}
