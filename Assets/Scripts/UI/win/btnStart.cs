using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnStart : MonoBehaviour
{
    private LevelSettings levelSettings;
    string e;
    void Start()
    {
        levelSettings = GameObject.Find("LevelSettings").GetComponent<LevelSettings>();
    }

    // Update is called once per frame
    public void Click()
    {
        LevelLoader.loadLevel("Level" + (levelSettings.nNivel+1));
    }
}
