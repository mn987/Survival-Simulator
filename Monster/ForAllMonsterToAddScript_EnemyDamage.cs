using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAllMonsterToAddScript_EnemyDamage : MonoBehaviour
{   
    
    //Số lượng thư mục quái
    public float numChildObject = 3;

    void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numChildObject ; i ++){
            Transform childObject = transform.GetChild(i);
            foreach (Transform monster in childObject){
                GameObject detectCollision = monster.gameObject;
                detectCollision.AddComponent(typeof(EnemyDamage));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
