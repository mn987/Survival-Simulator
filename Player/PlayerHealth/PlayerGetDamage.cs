using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamage : MonoBehaviour
{   
    public int damage = 1;

    public void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "EnemyCanAttack"){
            PlayerHealth.instance.PlayerTakeDamage(damage);

            HealthBarPlayer.instance.updateHealthBarPlayer(PlayerHealth.instance.healthPlayer, PlayerHealth.instance.maxHealthPlayer);
        }
    }
}
