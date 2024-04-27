using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletbotprefab;
    [SerializeField] public float health;

    private float bulletspeed = 5f;
    public float damagebullet = 10f;
    public static EnemyStats main;
    private float cooldown = 3;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            cooldown = 3;
            var bullet = Instantiate(bulletbotprefab, shootingPoint.position, bulletbotprefab.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletspeed;
        }   
    }
}
