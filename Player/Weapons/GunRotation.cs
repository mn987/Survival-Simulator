using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Transform gun;

    public float mouseSensibility = 100f;

    public float xRotation = 0f;

    void Update() {
        float mouseY = InputManager.instance.mouseY * mouseSensibility * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        gun.localRotation = Quaternion.Euler(xRotation, 0f, 0f);    
    }
}
