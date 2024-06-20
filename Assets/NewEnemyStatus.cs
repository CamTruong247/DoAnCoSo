using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewEnemyStatus : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject range;
    [SerializeField] private GameObject attackpoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject point;
    [SerializeField] private Animator animator;

    private GameObject enemy;
    public float radius;
    public float radiusattack;
    public float speed;
    public float huong = 1;
    public LayerMask layer;
    private float cooldownattack = 0.8f;
    public float damageattack;
    public float health;


    void Update()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(range.transform.position, radius, range.transform.position, 0f, layer);
        if(hits.Length > 0)
        {
            if (player.transform.position.x - 1.5 > gameObject.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            }
            else if (player.transform.position.x + 1.5 < gameObject.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            }
            Attack();
        }
        else
        {
            if(gameObject.transform.position.x > point.transform.position.x + 2)
            {
                huong = -1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if(gameObject.transform.position.x < point.transform.position.x - 2)
            {
                huong = 1;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            rb.velocity = new Vector2(huong * speed, rb.velocity.y);
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = Color.red;
    //    Handles.DrawWireDisc(attackpoint.transform.position, attackpoint.transform.forward, radiusattack);
    //}

    public void UpdateHealth(float health)
    {
        this.health -= health;
        if (this.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Attack()
    {
        RaycastHit2D[] hits2 = Physics2D.CircleCastAll(attackpoint.transform.position, radiusattack, attackpoint.transform.position, 0f, layer);
        if (hits2.Length > 0)
        {
            cooldownattack -= Time.deltaTime;
            if (cooldownattack <= 0)
            {
                cooldownattack = 1.5f;
                foreach (RaycastHit2D hit2 in hits2)
                {
                    animator.SetTrigger("Attack");
                    hit2.transform.GetComponent<PlayerStats>().UpdateHealth(damageattack);
                }
            }
        }
    }
}
