using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBottleHealth : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<PlayerStats>().UpdateUseHealth(1);
            Destroy(gameObject);
        }
    }
}
