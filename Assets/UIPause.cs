using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPause : MonoBehaviour
{
    public bool check;
    public static UIPause main;

    private void Awake()
    {
        main = this;
    }

    public void PauseGame()
    {
        PlayerMovement.main.audioManager.StopWalkSFX();
        if (check)
        {
            Time.timeScale = 1;
            check = false;
        }
        else
        {
            Time.timeScale = 0;
            check = true;
        }
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
