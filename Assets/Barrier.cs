using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float health = 10;

    public void UpdateHealth(float health)
    {
        this.health -= health;
        if (this.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
