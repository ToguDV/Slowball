using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AdsArenaManager : MonoBehaviour
{
    private RewardedAd rewardedAd;
    public bool productionMode;
    public string adUnitId;
    void Start()
    {
        if (!productionMode)
        {
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
        }

        MobileAds.Initialize(initStatus => { });
        CreateAndLoadRewardedAd();
        Invoke("UserChoseToWatchAd", 5f);
    }

    public void CreateAndLoadRewardedAd()
    {

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
    }

    private void HandleRewardedAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("Ad de recompensa cargado");
    }

    private void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    private void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log("HandleRewardedAdRewarded event received for " + amount.ToString() + " " + type);
    }

    // Update is called once per frame
    void Update()
    {

    }
}