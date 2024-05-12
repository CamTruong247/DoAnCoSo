using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] movepoint;
    [SerializeField] public float movespeed;
    [SerializeField] private GameObject enemyprefab;
    [SerializeField] private Transform spawnpoint;

    private GameObject enemy;
    public int movepointindex = 0;
    public static EnemyMovement main;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        enemy = Instantiate(enemyprefab, spawnpoint.position, Quaternion.identity);
    }
    private void Update()
    {
        EnemyMove();
    }

    public void EnemyMove()
    {
        if (gameObject != null)
        {
            if (Vector2.Distance(enemy.transform.position, movepoint[movepointindex].position) < 0.2f)
            {
                enemy.transform.Rotate(0, 180, 0);
                if (movepointindex < movepoint.Length - 1)
                {
                    movepointindex++;
                }
                else
                {
                    movepointindex--;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        enemy.GetComponent<Rigidbody2D>().velocity = enemy.transform.right * movespeed;

    }
}
