using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaLoader : MonoBehaviour
{
    public int maxArenas;
    int rand = 0;
    int randScene;

    private void OnEnable()
    {
        RestartFast.onRestart += loadArena;
    }

    private void OnDisable()
    {
        RestartFast.onRestart -= loadArena;
    }
    public void loadArena()
    {
        rand = Random.Range(0, 1);
        if (rand == 0)
        {
            randScene = Random.Range(1, maxArenas+1);
            if (SceneManager.GetActiveScene().name == "Arena"+randScene)
            {

            }

            else
            {
                Shooter.temp = false;
                Shooter.canShoot = true;
                Time.timeScale = 1;
                LevelLoader.loadLevel("Arena" + randScene);
            }
        }
    }
}
