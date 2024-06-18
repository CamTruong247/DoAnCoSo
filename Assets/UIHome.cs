using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHome : MonoBehaviour
{
    public void LoadScene(string play)
    {
        if(play == "Map0")
        {
            PlayerPrefs.DeleteKey("Map");
            PlayerPrefs.DeleteKey("Mana");
            PlayerPrefs.DeleteKey("Health");
            PlayerPrefs.SetString("UseHealth", "2");
            PlayerPrefs.SetString("UseMana", "2");
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
