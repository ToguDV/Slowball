using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnStart : MonoBehaviour
{
    private LevelSettings levelSettings;
    void Start()
    {
        levelSettings = GameObject.Find("LevelSettings").GetComponent<LevelSettings>();
    }

    // Update is called once per frame
    public void Click()
    {
        
    }
}
