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

    static public KMGMs_AdManager instance;

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

    public void PlayInterstitialAd() //タイトル戻りのときはさしこみ広告
    {
        if (((PlayerPrefs.GetInt("kmhh_PlayCount", 0)) % 2) == 0)
        {

            if (!Advertisement.IsReady(interstitialAd))
            {
                return;
            }
            Advertisement.Show(interstitialAd);
        }
        else{

            BackToKMGMs();
        }
    }

    public void PlayRewardedVdeoAd() //Continueのときは動画広告
    {
        if (((PlayerPrefs.GetInt("kmhh_PlayCount", 0)) % 2) == 0)
        {

            if (!Advertisement.IsReady(rewardedVideoAd))
            {
                return;
            }
            Advertisement.Show(rewardedVideoAd);
        }
        else{

            ContinueKMHH();
        }
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
                    ContinueKMHH();
                }
                if (placementId == interstitialAd)
                {
                    Debug.Log("Finished interstitial");
                    BackToKMGMs();
                }
                break;
            case ShowResult.Skipped:
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
            KMGMs_SoundManager.lifeJudge = true;
        Invoke("DerayMoveKMGMs", 0.5f);
    }

    public void ContinueKMHH()
    {
        KMGMs_SoundManager.lifeJudge = true;
        Invoke("DerayMoveKMHH", 0.5f);
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
