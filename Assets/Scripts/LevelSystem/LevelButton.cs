using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro.text = level + "";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        SceneManager.LoadSceneAsync("Level"+level);
    }
}
