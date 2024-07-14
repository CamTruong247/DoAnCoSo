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
        PlayerPrefs.SetString("UseHealth", PlayerStats.main.txtusehealth.text);
        PlayerPrefs.SetString("UseMana", PlayerStats.main.txtusemana.text);
        PlayerPrefs.SetString("Money", MoneyUI.main.txtmoney.text);
        PlayerPrefs.SetFloat("Attack", PlayerStats.main.damageattack);
        PlayerPrefs.SetFloat("Skill", PlayerStats.main.damagebullet);
        PlayerPrefs.SetFloat("Map",SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitions.SetTrigger("Start");
    }
}
