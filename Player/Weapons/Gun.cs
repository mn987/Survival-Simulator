using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{   
    //Vị trí viên đạn bắn ra
    public Transform bulletSpawnPoint;
    //Viên đạn
    public GameObject bulletPrefab;
    //Tốc độ bay của viên đạn
    public float bulletSpeed = 30f;

    //Dùng để điều chỉnh thời gian giữa những phát bắn
    protected float timeShootPerSecond = 0.1f;

    protected float oldShootingTime;

    //num Bullet
    public float numBullet;
    public float reloadTime = 0;
    public float maxBullet = 30;

    private void Start() {
        numBullet = 0;
    }

    void Update() {
        
        if (Input.GetMouseButton(0) && Time.time > oldShootingTime + timeShootPerSecond && numBullet < maxBullet){
            oldShootingTime = Time.time;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            numBullet += 1;
            ///
            /// Sự khác biệt giữa vector3.forward là transform.forward
            /// Vector3.forward = (0,0,1)
            /// transform.forward nó còn phụ thuộc vào góc quay mà đối tượng gán vào để khởi tạo
            /// vd: nếu khởi tạo viên đạn ở một object thì mặc định transform.forward sẽ trả về giá trị là (0,0,1) nhưng nếu ta quay đối tượng trên một góc 90" theo
            /// trục y thì lúc này transform.forward sẽ trả về vector (1,0,0)
            //https://answers.unity.com/questions/1311757/difference-between-transformforward-and-vector3for.html
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        if (numBullet >= maxBullet) {
            if (reloadTime < 5.0f) {
                PlayerCtl.instance.speed = 0.5f;
                PlayerCtl.instance.isloading = true;
                reloadTime += Time.deltaTime;
            }
            else {
                PlayerCtl.instance.speed = 3.0f;
                PlayerCtl.instance.isloading = false;
                reloadTime = 0.0f;
                numBullet = 0;
            }
        }
    }
}
