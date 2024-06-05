using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("References")]
   
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] public Image healthbar;
    [SerializeField] public Image healthbar1;
    [SerializeField] public Image manabar;
    [SerializeField] public Image manabar1;
    [SerializeField] private GameObject attackpoint;
    [SerializeField] private GameObject pauseblack;
    [SerializeField] private GameObject pausegame;
    
    AudioManager audioManager;

    [Header("Attributes")]
    public float mana = 100;
    public float health = 100;
    private float bulletspeed = 8f;
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
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {

        if(PlayerPrefs.HasKey("Mana"))
        {
            mana = PlayerPrefs.GetFloat("Mana");
        }
        if (PlayerPrefs.HasKey("Health"))
        {
            health = PlayerPrefs.GetFloat("Health");
        }
    }
    private void Update()
    {
        
        if (Time.timeScale == 1)
        {
            cooldownbullet += Time.deltaTime;
            cooldownattack += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.J) && cooldownattack >= 0.9f && PlayerMovement.main.IsGrounded())
            {
                PlayerMovement.main.animator.SetTrigger("Attack");                
                cooldownattack = 0;
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.K) && cooldownbullet >= 2f && PlayerMovement.main.IsGrounded())
            {
                if (mana >= 15)
                {
                    audioManager.PlaySFX(audioManager.skill);
                    PlayerMovement.main.animator.SetTrigger("Skill");
                    cooldownbullet = 0;
                    var bullet = Instantiate(bulletprefab, shootingPoint.position, bulletprefab.transform.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = shootingPoint.right * bulletspeed;
                    mana -= 15;
                    Manabar();
                }
            }
            if (mana < 100)
            {
                mana += Time.deltaTime;
                Manabar();
            }

            if (health < 100)
            {
                health += 0.5f * Time.deltaTime;
                healthbar.fillAmount = health / 100f;
                healthbar1.fillAmount = health / 100f;
            }
        }        
    }
    private void Manabar()
    {
        manabar.fillAmount = mana / 100f;
        manabar1.fillAmount = mana / 100f;
    }
    private void Attack()
    {
        audioManager.PlaySFX(audioManager.attack);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(attackpoint.transform.position, radius, attackpoint.transform.position,0f,layer);
        foreach(RaycastHit2D hit in hits)
        {
            audioManager.PlaySFX(audioManager.attackenemy);
            hit.transform.GetComponent<EnemyStats>().UpdateHealth(damageattack);
        }
    }
    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = Color.red;
    //    Handles.DrawWireDisc(attackpoint.transform.position, attackpoint.transform.forward, radius);
    //}
    public void UpdateHealth(float health)
    {
        audioManager.PlaySFX(audioManager.damagehealth);
        this.health -= health;        
        if (this.health <= 0)
        {
            Destroy(gameObject);
            UIPause.main.PauseGame();
            pauseblack.SetActive(true);
            pausegame.SetActive(true);
        }
    }
}