using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArenaScoreboard : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI recordTxt;
    public static float time;
    bool enable;

    private float updateInterval = 1f; // Actualizar cada 1 segundo
    private float nextUpdateTime = 0f;

    private void Awake()
    {
        time = 0f;
        setEnable(false);
        UpdateScore(time);
    }

    private void OnEnable()
    {
        RestartFast.onRestart += ClearScore;
        DeathPlayer.onDeath += Desactivate;
        BtnRevive.onRevive += Activate;
        ThrowController.OnFirstClick += Activate;

    }

    private void OnDisable()
    {
        DeathPlayer.onDeath -= Desactivate;
        BtnRevive.onRevive -= Activate;
        ThrowController.OnFirstClick -= Activate;
        ThrowController.OnFirstClick -= Activate;
    }


    public void ClearScore()
    {
        time = 0;
        recordTxt.text = PlayerPrefs.GetInt("arenaRecord", 0) + "";
        UpdateScore(time);
    }

    void Start()
    {
        recordTxt.text = PlayerPrefs.GetInt("arenaRecord", 0) + "";
    }

    private void Update()
    {
        if (enable)
        {
            time += Time.deltaTime;

            if (Time.time >= nextUpdateTime)
            {
                UpdateScore(time);
                nextUpdateTime = Time.time + updateInterval;
            }
        }
    }

    void UpdateScore(float value)
    {
        int temp;
        temp = (int)Mathf.Round(value);
        scoreTxt.text = temp + "";
        if (temp > PlayerPrefs.GetInt("arenaRecord", 0))
        {
            PlayerPrefs.SetInt("arenaRecord", temp);
        }

    }

    void setEnable(bool value)
    {
        enable = value;
    }

    void Activate()
    {
        setEnable(true);
    }
    void Desactivate()
    {
        setEnable(false);
    }
}
