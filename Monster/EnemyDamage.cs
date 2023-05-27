using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{   
    //Tên quái vật đang được gắn script
    public string nameMonster;

    //Lượng damage nhận vào khi một viên đạn trúng phải
    public int damage = 1;

    private float maxHealth;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        nameMonster = gameObject.name;
        index = MonsterHealth.instance.listNameMonsters.IndexOf(nameMonster);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Bullet"){
            //Gọi hàm nhận damage từ đối tượng
            MonsterHealth.instance.TakeDamage(nameMonster, damage);

            //Phần xác định maxhealth thuộc của đối tượng nào, boss hay creep
            if (gameObject.name.Contains("the_dom")){
                maxHealth = MonsterHealth.instance.maxHealthBoss;
            }
            else {
                maxHealth = MonsterHealth.instance.maxHealthCreep;
            }

            //Goị hàm nhận damage lên phần healthBar
            HealthBar.instance.UpdateHealthBar(HealthBar.instance.listImage[index], MonsterHealth.instance.listHealthMonsters[index], maxHealth);
        }
    }
}
