using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyStats>().UpdateHealth(PlayerStats.main.damagebullet);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
}
