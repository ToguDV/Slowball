using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArenaScoreboard : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI recordTxt;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        recordTxt.text = PlayerPrefs.GetInt("arenaRecord", 0) + "";
    }

    private void Update()
    {
        time += Time.deltaTime;
        UpdateScore(time);
    }

    void UpdateScore(float value)
    {
        int temp;
        temp = (int)Mathf.Round(value);
        scoreTxt.text = temp + "";
        if(temp > PlayerPrefs.GetInt("arenaRecord", 0))
        {
            PlayerPrefs.SetInt("arenaRecord", temp);
        }
        
    }
}
