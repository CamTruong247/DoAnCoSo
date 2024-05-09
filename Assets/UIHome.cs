using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHome : MonoBehaviour
{
   public void LoadScene(string play)
   {
        SceneManager.LoadSceneAsync(play);
   }
   public void ExitGame()
   {
        Application.Quit();
   }
}
