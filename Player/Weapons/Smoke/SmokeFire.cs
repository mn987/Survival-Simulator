using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeFire : MonoBehaviour
{
    public GameObject smoke;

    public Transform bulletSpawmPoint;

    //Dùng để điều chỉnh thời gian giữa những phát bắn
    public float timeShootPerSecond = 0.1f;

    public float oldShootingTime;

    // void Start() {
    //     if (bulletSpawmPoint.tag == null){
    //         bulletSpawmPoint.tag = "BulletSpawmnPoint";
    //     }
    // }

    void Update() {
        if (Input.GetMouseButton(0) && Time.time > oldShootingTime + timeShootPerSecond){
        
        oldShootingTime = Time.time;
        
        if (PlayerCtl.instance.speed != 0.5f){
            Instantiate(smoke, bulletSpawmPoint.position, Quaternion.identity); //gameobject(smoke), bulletSpawmPoint.position, bulletSpawmPoint.rotation
        }
        //Quaternion.identity = bulletSpawmPoint.rotation but no rotation

        }


    }
}
