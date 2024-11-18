using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class BtnRevive : MonoBehaviour
{
    public delegate void ReviveAction();
    public static event ReviveAction onRevive;
    private string debugMessaje;
    public Text text;
    public GameObject loadingSprite;
    bool runingCoroutine;
    public GameObject btnQuit;
    private int currenTries;
    void Start()
    {
        currenTries = 0;
        loadingSprite.SetActive(false);
        runingCoroutine = false;
    }

    // Update is called once per frame

    public void click()
    {

    }




}
