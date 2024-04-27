using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats.main.health -= PlayerStats.main.damagebullet;
            if (EnemyStats.main.health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
