using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Advertisements;

public class BtnRevive : MonoBehaviour, IUnityAdsListener
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
        Advertisement.AddListener(this);
    }

    // Update is called once per frame

    public void click()
    {
        if (!runingCoroutine)
        {
            btnQuit.SetActive(false);
            StartCoroutine(CoroutineClick());
        }
    }

    IEnumerator CoroutineClick()
    {
        loadingSprite.SetActive(true);
        runingCoroutine = true;
        while (!Advertisement.IsReady() || !Advertisement.isInitialized)
        {
            currenTries++;
            if(currenTries >= AdsManager.maxTriesTimeOut)
            {
                btnQuit.SetActive(true);
                Destroy(gameObject);
                
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        runingCoroutine = false;
        Advertisement.Show(AdsManager.idAndroidReward);
        PlayerPrefs.SetFloat("currentPlayTime", 0f);
        loadingSprite.SetActive(false);

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (onRevive != null)
            {
                //    debugMessaje = "Succeful";
                onRevive();
                
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            //  debugMessaje = "Skipped";
            btnQuit.SetActive(true);
        }
        else if (showResult == ShowResult.Failed)
        {
            //    debugMessaje = ("Showw result failed.");
            btnQuit.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //debugMessaje = "ready";
    }

    public void OnUnityAdsDidError(string message)
    {
        btnQuit.SetActive(true);
        debugMessaje = message;
        gameObject.SetActive(false);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //debugMessaje = "did start";
    }

}
