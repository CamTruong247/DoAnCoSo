using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBottleMana : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<PlayerStats>().UpdateUseMana(1);
            Destroy(gameObject);
        }
    }
}
