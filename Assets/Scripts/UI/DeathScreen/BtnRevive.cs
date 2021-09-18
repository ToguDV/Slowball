using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Advertisements;

public class BtnRevive : MonoBehaviour, IUnityAdsListener {
    public delegate void ReviveAction();
    public static event ReviveAction onRevive;
    string gameIdAndroid = "4350991";
    string myPlacementId = "Rewarded_Android";
    bool testMode = true;
    public static bool ready;
    private string debugMessaje;
    public Text text;
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameIdAndroid, testMode);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = debugMessaje;
    }

    public void click()
    {
        if (ready)
        {
            Advertisement.Show(myPlacementId);
        }
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
        }
        else if (showResult == ShowResult.Failed)
        {
        //    debugMessaje = ("Showw result failed.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //debugMessaje = "ready";
        ready = true;
    }

    public void OnUnityAdsDidError(string message)
    {
        debugMessaje = message;
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //debugMessaje = "did start";
    }

}
