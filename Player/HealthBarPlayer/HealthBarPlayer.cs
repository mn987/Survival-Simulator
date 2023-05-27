using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{   
    public static HealthBarPlayer instance;

    public Image imageHealthBarPlayer;

    public void Awake() {

        HealthBarPlayer.instance = this;

        imageHealthBarPlayer = transform.GetChild(0).GetComponent<Image>();
    }

    public void updateHealthBarPlayer(float currentHealthPlayer, float maxHealthPlayer){
        imageHealthBarPlayer.fillAmount = currentHealthPlayer / maxHealthPlayer;
    }
}
