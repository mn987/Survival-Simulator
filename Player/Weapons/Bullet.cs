using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;

    void Awake() {
        Destroy(gameObject, life);    
    }
}
