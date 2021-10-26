using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnPause : MonoBehaviour
{
    public GameObject pauseContainer;
    public static bool isPaused;
    public void Click()
    {
        pauseContainer.SetActive(!pauseContainer.activeSelf);
        if (pauseContainer.activeSelf)
        {
            isPaused = true;
            Time.timeScale = 0f;
        }

        else
        {
            isPaused = false;
            Time.timeScale = 1f;
        }
    }
}
