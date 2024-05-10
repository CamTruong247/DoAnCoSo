using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletbotprefab;
    [SerializeField] public float health;
    [SerializeField] public GameObject rangeview;

    private float bulletspeed = 5f;
    public float damagebullet = 10f;
    public static EnemyStats main;
    private float cooldown = 1.5f;
    public float radius;
    public LayerMask layer;


    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        RangeView();
    }

    private void RangeView()
    {
        cooldown -= Time.deltaTime;
        RaycastHit2D[] hits = Physics2D.BoxCastAll(rangeview.transform.position
            , new Vector3(4, 0.5f, 0), 0f, Vector2.left, 0f, layer); 
        if (hits.Length > 0)
        {
            if (cooldown <= 0)
            {
                cooldown = 1.5f;
                var bullet = Instantiate(bulletbotprefab, shootingPoint.position, bulletbotprefab.transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletspeed;
            }
        }
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
