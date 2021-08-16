using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlayer : MonoBehaviour
{
    GameObject winWindows;
    public GameObject pause;
    public GameObject winEffect;
    public Animator animator;
    public Star[] stars;
    void Start()
    {

        winWindows = GameObject.Find("WinUI");
        winWindows.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("win"))
        {
            Win();
        }
    }


    public void Win()
    {

        foreach (var star in stars)
        {
            if (star)
            {
                Debug.Log("Estrella activa");
                star.sendToWin();
            }

            else
            {
                Debug.Log("no se pudo activar la estrella");
            }
        }
        Instantiate(winEffect, transform.position, Quaternion.identity);
        animator.SetBool("isWin", true);
        //pause.SetActive(false);
        winWindows.SetActive(true);
    }
}
