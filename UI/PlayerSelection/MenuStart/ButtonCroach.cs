using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCroach : MonoBehaviour
{   
    public GameObject effectBoom;

    private float timeDestroy;

     private void Start() {

        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);        

    }

    void TaskOnClick()
    {   
        var effect = Instantiate(effectBoom, transform);
        effect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);

        //delete image croach
        var temp = transform.GetComponent<Image>();
        Destroy(temp);

        //after 3s destroy effect
        Invoke("DestroyEffect", 3);

    }

    void DestroyEffect()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

}
