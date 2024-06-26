using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] movepoint;
    
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
        if (enemy != null)
        {
            if (Vector2.Distance(enemy.transform.position, movepoint[movepointindex].position) < 0.3f)
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

    
}
