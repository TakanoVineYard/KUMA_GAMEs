using UnityEngine;
using UnityEngine.Advertisements;
using static KMHH_ScoreResultManager;
using UnityEngine.SceneManagement; //シーン切り替え

public class KMGMs_AdManager : MonoBehaviour, IUnityAdsListener
{

    private string playStoreID = "4006125";
    private string appStoreID = "4006124";


    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    public bool isTestAd;

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

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }

    public void PlayRewardedVdeoAd()
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
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    Debug.Log("Reward The Player");
                    ContinueKMHH();
                }
                if (placementId == interstitialAd)
                {
                    Debug.Log("Finished interstitial");
                    BackToKMGMs();
                }
                break;

        }
    }

    public void BackToKMGMs()
    {
        Debug.Log("hogeOption");
        Invoke("DerayMoveKMGMs", 1.0f);
    }

    public void ContinueKMHH()
    {

        Debug.Log("hoge");
        Invoke("DerayMoveKMHH", 1.0f);
    }
    public void DerayMoveKMHH()
    {
        KMHH_TimeManager.gameStart = false;
        KMHH_TimeManager.gameFinish = false;

        SceneManager.LoadScene("KMHH");
        Debug.Log("hogehoge");
        KMHH_ScoreResultManager.HighsScoreSwitch = true;
    }

    public void DerayMoveKMGMs()
    {
        KMHH_TimeManager.gameStart = false;
        KMHH_TimeManager.gameFinish = false;


        SceneManager.LoadScene("KMGMs");
        KMHH_ScoreResultManager.HighsScoreSwitch = true;
    }
}
