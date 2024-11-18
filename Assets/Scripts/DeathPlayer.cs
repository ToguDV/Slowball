using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{
    public ArenaLoader arenaLoader;
    public GameObject templateDeath;
    public GameObject btnRevive;
    public GameObject btnQuit;
    public static bool isDead;
    public int maxRevives = 1;
    int currentRevives;
    public Animator animator;
    public GameObject deathEffect;
    public ThrowController throwController;
    public delegate void DeathAction();
    public static event DeathAction onDeath;
    public float restartDelay;
    bool once;
    private GameObject spawnPoint;
    public GameObject father;

    private void OnEnable()
    {
        RestartFast.onRestart += Reinicio;
        BtnRevive.onRevive += Revivir;
    }

    private void OnDisable()
    {
        RestartFast.onRestart -= Reinicio;
        BtnRevive.onRevive -= Revivir;
    }

    private void Awake()
    {
        PlayerPrefs.SetInt("currentDeaths", 0);
        Debug.Log("deaths = "+ PlayerPrefs.GetInt("currentDeaths", 0) + "/"+AdsManager.deathsToShowReward);
        spawnPoint = GameObject.Find("SpawnPoint");
        once = true;
        currentRevives = 0;
        isDead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && once)
        {
            once = false;
            if (onDeath != null)
            {
                onDeath();
            }
            PlayerPrefs.SetInt("currentDeaths", PlayerPrefs.GetInt("currentDeaths", 0) + 1);
            throwController.enabled = false;
            Instantiate(deathEffect, transform.position, transform.rotation);
            animator.SetBool("IsDeath", true);
            isDead = true;
            Time.timeScale = 1f;
            templateDeath.SetActive(true);
            btnQuit.SetActive(true);
            //if (currentRevives >= maxRevives)
            if(true)
            {
                btnQuit.SetActive(false);
                btnRevive.SetActive(false);
                Invoke("loadArena", restartDelay);
            }
            //No ha revivido mucho
            else
            {
                PlayerPrefs.SetFloat("currentPlayTime", ArenaScoreboard.time + PlayerPrefs.GetFloat("currentPlayTime", 0f));

                //SE MUESTRA LA OPCION DE REVIVIR
                if (ArenaScoreboard.time >= AdsManager.timeToShowReward)
                {
                    PlayerPrefs.SetInt("currentDeaths", 0);
                    btnRevive.SetActive(true);
                }

                else
                {
                    btnQuit.SetActive(false);
                    btnRevive.SetActive(false);
                    Invoke("loadArena", restartDelay);
                    if (PlayerPrefs.GetInt("currentDeaths", 0) >= AdsManager.deathsToShowReward)
                    {
                        Debug.Log("deaths = " + PlayerPrefs.GetInt("currentDeaths", 0) + "/" + AdsManager.deathsToShowReward);
                        PlayerPrefs.SetInt("currentDeaths", 0);
                    }

                }
            }
        }
    }

    private void loadArena()
    {
        RestartFast.Restart();
    }

    private void Revivir()
    {
        once = true;
        animator.SetBool("IsDeath", false);
        currentRevives++;
        templateDeath.SetActive(false);
        isDead = false;
        throwController.enabled = true;
    }

    private void Reinicio()
    {
        btnQuit.SetActive(false);
        btnRevive.SetActive(false);
        father.transform.position = spawnPoint.transform.position;
        once = true;
        animator.SetBool("IsDeath", false);
        templateDeath.SetActive(false);
        isDead = false;
        throwController.enabled = true;
        throwController.setFirstClick(true);
        currentRevives = 0;

    }
}
