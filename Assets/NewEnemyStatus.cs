using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewEnemyStatus : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject range;
    [SerializeField] private GameObject attackpoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject point;

    public float radius;
    public float radiusattack;
    public float speed;
    public float huong = 1;
    public LayerMask layer;
    private float cooldownattack = 1.5f;
    public float damageattack = 2f;

    void Update()
    {
        cooldownattack -= Time.deltaTime;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(range.transform.position, radius, range.transform.position, 0f, layer);
        if(hits.Length > 0)
        {
            Debug.Log(hits);
            if (player.transform.position.x - 1 > gameObject.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            }
            else if (player.transform.position.x + 1 < gameObject.transform.position.x)
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
    //    Handles.DrawWireDisc(range.transform.position, range.transform.forward, radius);
    //}
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(attackpoint.transform.position, attackpoint.transform.forward, radiusattack);
    }

    private void Attack()
    {
        RaycastHit2D[] hits2 = Physics2D.CircleCastAll(attackpoint.transform.position, radiusattack, attackpoint.transform.position, 0f, layer);
        if (hits2.Length > 0)
        {
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
