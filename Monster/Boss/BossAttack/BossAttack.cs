using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform player;
    public List<Transform> listBoss;

    public GameObject bulletBoss;

    //Distance player with boss if player in range attack boss, the void will call
    protected float distance;

    protected float rangeAttack = 30;


    //Dùng để điều chỉnh thời gian giữa những phát bắn
    protected float timeShootPerSecond = 0.4f;

    protected float oldShootingTime;

    protected float timeDestroy = 3f;

    private void Start() {
        foreach (Transform eachBoss in transform){
            listBoss.Add(eachBoss);
        }
    }

    private void Update() {

        foreach (Transform eachBoss in listBoss){
            distance = Vector3.Distance(player.position, eachBoss.position);

            if (distance < rangeAttack && Time.time > oldShootingTime + timeShootPerSecond){
                oldShootingTime = Time.time;
                
                BossAttackPlayer(eachBoss, distance);
            }
        }
    }

    void BossAttackPlayer(Transform bossSpawnPoint, float distance){
        //Xoay hướng spawn đạn vào player
        bossSpawnPoint.LookAt(player);

        GameObject bullet = Instantiate(bulletBoss, new Vector3(bossSpawnPoint.position.x, bossSpawnPoint.position.y + 2f, bossSpawnPoint.position.z), bossSpawnPoint.rotation);

        bullet.tag = "EnemyCanAttack";

        bullet.GetComponent<Rigidbody>().velocity = bossSpawnPoint.forward * distance;

        Destroy(bullet, timeDestroy);
    }
}
