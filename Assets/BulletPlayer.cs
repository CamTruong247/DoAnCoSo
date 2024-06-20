using Unity.Burst.CompilerServices;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            if(enemyStats != null)
            {
                enemyStats.UpdateHealth(PlayerStats.main.damagebullet);
            }
            NewEnemyStatus newEnemyStatus = collision.GetComponent<NewEnemyStatus>();
            if(newEnemyStatus != null)
            {
                newEnemyStatus.UpdateHealth(PlayerStats.main.damagebullet);
            }
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
}
