using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHome : MonoBehaviour
{
    public void LoadScene(string play)
   {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(play);
    }
   public void ExitGame()
   {
        Application.Quit();
    }
}
