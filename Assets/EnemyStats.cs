using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletbotprefab;
    [SerializeField] public float health;
    [SerializeField] public GameObject rangeview;
    [SerializeField] private EnemyType enemytype;
    [SerializeField] private GameObject attackpoint;

    public static EnemyStats main;
    private float bulletspeed = 5f;
    public float damagebullet = 10f;
    public float damageattack = 5f;    
    private float cooldownbullet = 1.5f;
    private float cooldownattack = 1.5f;
    public float radius;
    public LayerMask layer;

    private void Awake()
    {
        main = this;
    }

    public enum EnemyType
    {
        melee,
        range
    }

    private void Update()
    {
        RangeView();
    }

    private void RangeView()
    {
        cooldownbullet -= Time.deltaTime;
        cooldownattack -= Time.deltaTime;
       
        if (enemytype == EnemyType.range)
        {
            RaycastHit2D[] hits = Physics2D.BoxCastAll(rangeview.transform.position, new Vector3(4, 0.5f, 0), 0f, Vector2.left, 0f, layer);
            if (hits.Length > 0)
            {
                transform.GetComponent<EnemyMovement>().movespeed = 0;
                if (cooldownbullet <= 0)
                {
                    cooldownbullet = 1.5f;
                    var bullet = Instantiate(bulletbotprefab, shootingPoint.position, bulletbotprefab.transform.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletspeed;
                }
            }
        }
        if(enemytype == EnemyType.melee)
        {
            RaycastHit2D[] hits2 = Physics2D.CircleCastAll(attackpoint.transform.position, radius, attackpoint.transform.position, 0f, layer);
            if (hits2.Length > 0)
            {
                transform.GetComponent<EnemyMovement>().movespeed = 0;
                Debug.Log("aaaaa");
                if (cooldownattack <= 0)
                {
                    cooldownattack = 1.5f;
                    foreach (RaycastHit2D hit2 in hits2)
                    {
                            
                        hit2.transform.GetComponent<PlayerStats>().UpdateHealth(damageattack);
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(attackpoint.transform.position, attackpoint.transform.forward, radius);
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = Color.red;
    //    Handles.DrawWireCube(rangeview.transform.position,new Vector3(4,0.5f,0));
    //}

    public void UpdateHealth(float health)
    {
        this.health -= health;
        if(this.health<= 0)
        {
            Destroy(gameObject);
        }
    }
}
