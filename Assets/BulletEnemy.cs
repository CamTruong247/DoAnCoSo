using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStats.main.UpdateHealth(EnemyStats.main.damagebullet);
            PlayerStats.main.healthbar.fillAmount = PlayerStats.main.health / 100;
            PlayerStats.main.healthbar1.fillAmount = PlayerStats.main.health / 100;
            Destroy(gameObject);
        }

    }
}
