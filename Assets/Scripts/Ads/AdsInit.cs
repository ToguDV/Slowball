using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInit : MonoBehaviour
{
    void Start()
    {
        if (!Advertisement.isInitialized)
        {
            Advertisement.Initialize(AdsManager.gameIdAndroid, AdsManager.testMode);
        }
    }
}
