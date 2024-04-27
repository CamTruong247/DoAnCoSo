using Unity.VisualScripting;
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

    private float bulletspeed = 5f;
    public float damagebullet = 4f;
    public static PlayerStats main;
    private float cooldown = 2;
    

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
        cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.K) && cooldown <= 0)
        {            
            if(mana >= 15)
            {
                cooldown = 2;
                var bullet = Instantiate(bulletprefab, shootingPoint.position, bulletprefab.transform.rotation); 
                bullet.GetComponent<Rigidbody2D>().velocity = shootingPoint.right * bulletspeed;
                mana -= 15;
                manabar.fillAmount = mana / 100f;
                manabar1.fillAmount = mana / 100f;
            }
        }
        if(mana < 100)
        {
            mana += Time.deltaTime;
            manabar.fillAmount = mana / 100f;
            manabar1.fillAmount = mana / 100f;
        }
        
        if(health < 100)
        {
            health += 0.5f * Time.deltaTime;
            healthbar.fillAmount = health / 100f;
            healthbar1.fillAmount = health / 100f;
        }
        
    }
}