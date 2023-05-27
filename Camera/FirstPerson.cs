using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{   
    public Transform player;

    public float mouseSensibility = 100f;

    public float xRotation = 0f;

    private bool hasButton_V_down;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = InputManager.instance.mouseX * mouseSensibility * Time.deltaTime;
        float mouseY = InputManager.instance.mouseY * mouseSensibility * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

        //Set camera view when player hit V
        if (Input.GetKeyDown(KeyCode.V) && hasButton_V_down == false){
            hasButton_V_down = true;
            ChangerViewCamera_ButtonDown();
        }
        else if (Input.GetKeyDown(KeyCode.V) && hasButton_V_down == true){
            hasButton_V_down = false;
            ChangerViewCamera_ButtonUp();
        }

    }

    void ChangerViewCamera_ButtonDown(){
        transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
    }

    void ChangerViewCamera_ButtonUp(){
        transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
    }
}
