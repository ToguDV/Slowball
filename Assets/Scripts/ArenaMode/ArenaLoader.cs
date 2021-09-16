using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaLoader : MonoBehaviour
{
    public int maxArenas; 
    public void loadArena()
    {
        Time.timeScale = 1;
        LevelLoader.loadLevel("Arena"+Random.Range(1, maxArenas+1));
    }
}
