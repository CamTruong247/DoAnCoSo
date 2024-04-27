using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStats.main.health -= EnemyStats.main.damagebullet;
            PlayerStats.main.healthbar.fillAmount = PlayerStats.main.health / 100;
            PlayerStats.main.healthbar1.fillAmount = PlayerStats.main.health / 100;
            if (PlayerStats.main.health <= 0)
            {
                Destroy(collision.gameObject);
                Time.timeScale = 0;
            }
        }
        Destroy(gameObject);
    }
}
