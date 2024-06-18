using TMPro;
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
    [SerializeField] private GameObject gameover;
    [SerializeField] public TextMeshProUGUI txtusehealth;
    [SerializeField] public TextMeshProUGUI txtusemana;

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
    public LayerMask layer2;
    private float usehealth;
    private float usemana;

    private void Awake()
    {

        main = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Mana"))
        {
            mana = PlayerPrefs.GetFloat("Mana");
        }
        if (PlayerPrefs.HasKey("Health"))
        {
            health = PlayerPrefs.GetFloat("Health");
        }
        if (PlayerPrefs.HasKey("UseHealth"))
        {
            txtusehealth.text = PlayerPrefs.GetString("UseHealth");
        }
        if (PlayerPrefs.HasKey("UseMana"))
        {
            txtusemana.text = PlayerPrefs.GetString("UseMana");
        }
        usehealth = float.Parse(txtusehealth.text);
        usemana = float.Parse(txtusemana.text);
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
            UseHealth();
            UseMana();
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
            EnemyStats enemyStats = hit.transform.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.UpdateHealth(damageattack);
            }
            NewEnemyStatus newEnemyStatus = hit.transform.GetComponent<NewEnemyStatus>();
            if (newEnemyStatus != null)
            {
                newEnemyStatus.UpdateHealth(damageattack);
            }
        }
        RaycastHit2D[] hit2s = Physics2D.CircleCastAll(attackpoint.transform.position, radius, attackpoint.transform.position, 0f, layer2);
        foreach (RaycastHit2D hit in hit2s)
        {
            audioManager.PlaySFX(audioManager.attackbarrier);
            hit.transform.GetComponent<Barrier>().UpdateHealth(damageattack);
        }
    }
    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = Color.red;
    //    Handles.DrawWireDisc(attackpoint.transform.position, attackpoint.transform.forward, radius);
    //}
    public void UpdateHealth(float health)
    {
        audioManager.PlayHitDamageSFX(audioManager.damagehealth);
        this.health -= health;        
        if (this.health <= 0)
        {
            Destroy(gameObject);
            UIPause.main.PauseGame();
            pauseblack.SetActive(true);
            gameover.SetActive(true);
        }
    }

    private void UseHealth()
    {
        float healing = 15;
        if (Input.GetKeyDown(KeyCode.U))
        {
            if(usehealth > 0)
            {
                if(health < 100)
                {
                    health += healing;
                    usehealth--;
                    txtusehealth.text = usehealth.ToString();
                }
            }
        }
    }

    public void UpdateUseHealth(float usehealth)
    {
        this.usehealth += usehealth;
        txtusehealth.text = this.usehealth.ToString();
    }

    private void UseMana()
    {
        float manaing = 15;
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (usemana > 0)
            {
                if(mana < 100)
                {
                    mana += manaing;
                    usemana--;
                    txtusemana.text = usemana.ToString();
                }
            }
        }
    }
    public void UpdateUseMana(float usemana)
    {
        this.usemana += usemana;
        txtusemana.text = this.usemana.ToString();
    }
}