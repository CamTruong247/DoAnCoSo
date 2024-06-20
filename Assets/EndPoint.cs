using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] GameObject endpoint;
    [SerializeField] GameObject pauseblack;
    [SerializeField] GameObject enemyprefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyprefab == null)
        {
            if (collision.gameObject.tag == "Player")
            {
                UIPause.main.PauseGame();
                pauseblack.SetActive(true);
                endpoint.SetActive(true);
            } 
        }
    }
}
