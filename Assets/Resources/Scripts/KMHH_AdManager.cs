﻿using UnityEngine;
using UnityEngine.Advertisements;
using static KMHH_ScoreResultManager;
using UnityEngine.SceneManagement; //シーン切り替え
using static KMHH_TimeManager;

public class KMHH_AdManager : MonoBehaviour, IUnityAdsListener
{


    private string playStoreID = "4006125";
    private string appStoreID = "4006124";


    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    public bool isTestAd;

    static public KMHH_AdManager instance;

    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }

    private void Start()
    {

        Advertisement.AddListener(this);
        InitializeAdvertisement();
    }
    private void InitializeAdvertisement()
    {

#if UNITY_ANDROID
        Advertisement.Initialize(playStoreID, isTestAd);
#endif
#if UNITY_IOS
        Advertisement.Initialize(appStoreID, isTestAd);
#endif
    }


    public void PlayRewardedVdeoAd() //Continueのときは動画広告
    {

        if (!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        Advertisement.Show(rewardedVideoAd);


    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                if (placementId == rewardedVideoAd)
                {
                    Debug.Log("Reward The Player");
                }
                if (placementId == interstitialAd)
                {
                    Debug.Log("Finished interstitial");
                }
                break;
            case ShowResult.Skipped:
                if (placementId == rewardedVideoAd)
                {
                    Debug.Log("Reward The Player");
                }
                if (placementId == interstitialAd)
                {
                    Debug.Log("Finished interstitial");
                }
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    Debug.Log("Reward The Player");
                }
                if (placementId == interstitialAd)
                {
                    Debug.Log("Finished interstitial");
                }
                break;

        }
    }


}
