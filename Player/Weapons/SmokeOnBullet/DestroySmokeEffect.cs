using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySmokeEffect : MonoBehaviour
{   
    //Thêm hiệu ứng nổ khi đạn va chạm với vật thể
    public GameObject smallExplosionEffect;

    public float time = 1f;

    private void OnCollisionEnter(Collision other) {
        if (other != null && other.transform.tag != "Ground"){
            var smallExpolsion = Instantiate(smallExplosionEffect, transform.position, Quaternion.identity);
            Destroy(smallExpolsion, time);
        }
    }
    
}
