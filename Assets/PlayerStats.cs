using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public float mana;
    [SerializeField] public float health;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] public Image healthbar;
    [SerializeField] public Image healthbar1;
    [SerializeField] public Image manabar;
    [SerializeField] public Image manabar1;
    [SerializeField] private GameObject attackpoint;
    
        
    private float bulletspeed = 5f;
    public float damagebullet = 4f;
    public float damageattack = 2f;
    public static PlayerStats main;
    private float cooldownbullet;
    private float cooldownattack;
    public float radius;
    public LayerMask layer;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        mana = 100;
        health = 100;
    }

    private void Update()
    {
        cooldownbullet += Time.deltaTime;
        cooldownattack += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.J) && cooldownattack >= 0.9f)
        {
            cooldownattack = 0;
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.K) && cooldownbullet >= 2f)
        {            
            if(mana >= 15)
            {
                cooldownbullet = 0;
                var bullet = Instantiate(bulletprefab, shootingPoint.position, bulletprefab.transform.rotation); 
                bullet.GetComponent<Rigidbody2D>().velocity = shootingPoint.right * bulletspeed;
                mana -= 15;
                Manabar();
            }
        }
        if(mana < 100)
        {
            mana += Time.deltaTime;
            Manabar();
        }
        
        if(health < 100)
        {
            health += 0.5f * Time.deltaTime;
            healthbar.fillAmount = health / 100f;
            healthbar1.fillAmount = health / 100f;
        }        
    }
    private void Manabar()
    {
        manabar.fillAmount = mana / 100f;
        manabar1.fillAmount = mana / 100f;
    }
    private void Attack()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(attackpoint.transform.position, radius, attackpoint.transform.position,0f,layer);
        foreach(RaycastHit2D hit in hits)
        {
            hit.transform.GetComponent<EnemyStats>().UpdateHealth(damageattack);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(attackpoint.transform.position, attackpoint.transform.forward, radius);
    }
    public void UpdateHealth(float health)
    {
        this.health -= health;
        if (this.health <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}