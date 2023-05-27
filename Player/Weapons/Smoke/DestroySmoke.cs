using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySmoke : MonoBehaviour
{
    public float destroySmokeTime = 1f;

    private void Awake() {
        Destroy(gameObject, destroySmokeTime);
    }
}
