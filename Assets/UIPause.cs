using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    public bool check;

    public void PauseGame()
    {
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
}
