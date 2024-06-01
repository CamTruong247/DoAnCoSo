using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHome : MonoBehaviour
{
    public void LoadScene(string play)
    {
        if(play == "Map0")
        {
            PlayerPrefs.DeleteAll();
        }
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(play);
    }

    public void ContinueLoadScene()
    {
        if (PlayerPrefs.HasKey("Map"))
        {
            int map = (int)PlayerPrefs.GetFloat("Map");
            SceneManager.LoadSceneAsync(map);
        }
    }

   public void ExitGame()
   {
        Application.Quit();
    }
}
