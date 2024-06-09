using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class TrapHand : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject attackpoint;

    private float damage = 2f;
    public float radius;
    public LayerMask layer;
    public float cooldownattack = 0;

    private void Update()
    {
        cooldownattack += Time.deltaTime;
        if(cooldownattack > 1)
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(attackpoint.transform.position, radius, attackpoint.transform.position, 0f, layer);
            foreach (RaycastHit2D hit in hits)
            {
                animator.SetTrigger("Attack");
                hit.transform.GetComponent<PlayerStats>().UpdateHealth(damage);
                cooldownattack = 0;
            }
        }

    }
    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = Color.red;
    //    Handles.DrawWireDisc(attackpoint.transform.position, attackpoint.transform.forward, radius);
    //}
}
