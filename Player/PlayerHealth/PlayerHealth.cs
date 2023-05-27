using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    public static PlayerHealth instance;

    public float healthPlayer;

    public float maxHealthPlayer = 5;

    //Check player is dead or not
    protected bool playerisDead;

    //Lấy ra thư mục enemy để tắt
    public GameObject folderEnemy;

    private void Awake() {

        PlayerHealth.instance = this;

        healthPlayer = maxHealthPlayer;
    }

    public void PlayerTakeDamage(int amount){
        this.healthPlayer -= amount;

        if (healthPlayer <= 0 && !playerisDead){
            playerisDead = true;
            Debug.Log("Player is Dead");
            gameObject.name = gameObject.name + " isDead";

            //Tat script di chuyen cua player
            gameObject.GetComponent<PlayerCtl>().enabled = false;

            //Tat script goc nhin thu nhat cua player
            // GameObject.FindGameObjectsWithTag("MainCamera").SetActive(false);
            GameObject.FindWithTag("MainCamera").GetComponent<FirstPerson>().enabled = false;

            //khoa vi tri cx nhu goc xoay cua player
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            //Tat gameobject weapon cua player
            GameObject.FindGameObjectWithTag("Weapon").SetActive(false);
            //Tắt thư mục quái để quái đừng di chuyển
            folderEnemy.SetActive(false);
        }
    }
}
