using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] Animator transitions;

    public static SceneController main;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
            DontDestroyOnLoad(main); 
        }
        else
        {
            Destroy(main);
        }
    }

    public void NextMap()
    {
        transitions.SetTrigger("End");
        PlayerPrefs.SetFloat("Mana", PlayerStats.main.mana);
        PlayerPrefs.SetFloat("Health", PlayerStats.main.health);
        PlayerPrefs.SetFloat("Map",SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitions.SetTrigger("Start");
    }
}
