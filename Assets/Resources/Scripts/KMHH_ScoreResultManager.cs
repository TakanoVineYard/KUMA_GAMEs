using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？
using static KMHH_ScoreManager;
using UnityEngine.SceneManagement; //シーン切り替え
using TMPro; //TextMeshPro用
using static KMGMs_SoundManager;
using System;

public class KMHH_ScoreResultManager : MonoBehaviour
{

    public int KmhhHighScore = 0; // スコア変数
    public GameObject resultMaxComboObj;
    public GameObject resultScoreTextObj;
    public GameObject resultHighScoreTextObj;
    public GameObject resultHighScoreMarkObj;
    public GameObject resultScoreExcellentObj;
    public GameObject resultScoreGreatObj;
    public GameObject resultScoreGoodObj;
    public GameObject resultScoreNotGoodObj;
    public GameObject resultScorePoorObj;
    public GameObject resultScoreMissObj;
    public GameObject kmhhGameLevelObj;

    TextMeshProUGUI resultMaxComboText;
    TextMeshProUGUI resultScoreText;
    TextMeshProUGUI resultHighScoreText;
    TextMeshProUGUI resultScoreExcellent;
    TextMeshProUGUI resultScoreGreat;
    TextMeshProUGUI resultScoreGood;
    TextMeshProUGUI resultScoreNotGood;
    TextMeshProUGUI resultScorePoor;
    TextMeshProUGUI resultScoreMiss;
    TextMeshProUGUI kmhhGameLevel;


    public int exchangeToKumaCoin;
    public int oldTotalKumaCoinValue;
    public int newTotalKumaCoinValue;

    public static bool HighsScoreSwitch = false;

    // Start is called before the first frame update
    public void Start()
    {
        // スコアのロード
        KmhhHighScore = CryptoPlayerPrefs.GetInt("KMHH_HighScore", 0);
        /*
        resultMaxComboObj = GameObject.Find("ResultMaxCombo");
        resultScoreTextObj = GameObject.Find("ResultScore");
        resultScoreExcellentObj = GameObject.Find("ResultExcellent");
        resultScoreGreatObj = GameObject.Find("ResultGreat");
        resultScoreGoodObj = GameObject.Find("ResultGood");
        resultScoreNotGoodObj = GameObject.Find("ResultNotGood");
        resultScorePoorObj = GameObject.Find("ResultPoor");
        resultScoreMissObj = GameObject.Find("ResultMiss");

*/
        resultMaxComboText = resultMaxComboObj.GetComponent<TextMeshProUGUI>();
        resultHighScoreText = resultHighScoreTextObj.GetComponent<TextMeshProUGUI>();
        resultScoreText = resultScoreTextObj.GetComponent<TextMeshProUGUI>();
        resultScoreExcellent = resultScoreExcellentObj.GetComponent<TextMeshProUGUI>();
        resultScoreGreat = resultScoreGreatObj.GetComponent<TextMeshProUGUI>();
        resultScoreGood = resultScoreGoodObj.GetComponent<TextMeshProUGUI>();
        resultScoreNotGood = resultScoreNotGoodObj.GetComponent<TextMeshProUGUI>();
        resultScorePoor = resultScorePoorObj.GetComponent<TextMeshProUGUI>();
        resultScoreMiss = resultScoreMissObj.GetComponent<TextMeshProUGUI>();
        kmhhGameLevel = kmhhGameLevelObj.GetComponent<TextMeshProUGUI>();


        resultMaxComboText.text = "<bounce>" + KMHH_ScoreManager.maxCombo.ToString();
        resultScoreText.text = "<bounce>" + ((int)KMHH_ScoreManager.totalScore).ToString();
        resultScoreExcellent.text = "<bounce>" + KMHH_ScoreManager.scoreExcellent.ToString();
        resultScoreGreat.text = "<bounce>" + KMHH_ScoreManager.scoreGreat.ToString();
        resultScoreGood.text = "<bounce>" + KMHH_ScoreManager.scoreGood.ToString();
        resultScoreNotGood.text = "<bounce>" + KMHH_ScoreManager.scoreNotGood.ToString();
        resultScorePoor.text = "<bounce>" + KMHH_ScoreManager.scorePoor.ToString();
        resultScoreMiss.text = "<bounce>" + KMHH_ScoreManager.scoreMiss.ToString();


        switch (PlayerPrefs.GetInt("kmhhGameLevel", 0))
        {
            case 0:
                kmhhGameLevel.text = "<wave a=0.5><color=#F9FF69>NORMAL";
                break;
            case 1:
                kmhhGameLevel.text = "<wave a=0.5><color=#69E7FF>EASY";
                break;
            case 2:
                kmhhGameLevel.text = "<wave a=0.5><color=#FF3200>HARD";
                break;

        }



        HighsScoreSwitch = true;

        resultHighScoreMarkObj.SetActive(false);

        //スコアリセット(デバッグ時)
        //PlayerPrefs.DeleteKey("KMHH_HighScoreNormal");
        //PlayerPrefs.DeleteKey("KMHH_HighScoreEasy");
        //PlayerPrefs.DeleteKey("KMHH_HighScoreHard");
        KMHHExchangeToKumaCoin(); //クマコイン精算

    }
    public void Update()
    {

        if (HighsScoreSwitch)
        {

            switch (KMGMs_GameLevelManager.kmhh_GameLevel)
            {
                case 0:

                    KmhhHighScore = CryptoPlayerPrefs.GetInt("KMHH_HighScoreNormal", 0);

                    Debug.Log("のーまるのハイスコア:" + KmhhHighScore);
                    break;
                case 1:

                    KmhhHighScore = CryptoPlayerPrefs.GetInt("KMHH_HighScoreEasy", 0);

                    Debug.Log("いーじーのハイスコア:" + KmhhHighScore);
                    break;
                case 2:

                    KmhhHighScore = CryptoPlayerPrefs.GetInt("KMHH_HighScoreHard", 0);

                    Debug.Log("はーどのハイスコア:" + KmhhHighScore);
                    break;

            }

            KMHH_ScoreSave((int)KMHH_ScoreManager.totalScore);

            resultHighScoreText.text = "<bounce>" + KmhhHighScore.ToString();

            HighsScoreSwitch = false;

        }
    }


    public void KMHH_ScoreSave(int score)
    {
        if (KmhhHighScore <= score)
        {
            switch (KMGMs_GameLevelManager.kmhh_GameLevel)
            {
                case 0:

                    // スコアを保存
                    CryptoPlayerPrefs.SetInt("KMHH_HighScoreNormal", score);
                    CryptoPlayerPrefs.Save();
                    Debug.Log("のーまるのハイスコアセーブ" + score);
                    break;

                case 1:

                    // スコアを保存
                    CryptoPlayerPrefs.SetInt("KMHH_HighScoreEasy", score);
                    CryptoPlayerPrefs.Save();
                    Debug.Log("いーじーのハイスコアセーブ" + score);
                    break;

                case 2:
                    // スコアを保存
                    CryptoPlayerPrefs.SetInt("KMHH_HighScoreHard", score);
                    CryptoPlayerPrefs.Save();
                    Debug.Log("はーどのハイスコアセーブ" + score);
                    break;
            }

            resultHighScoreMarkObj.SetActive(true);

            KmhhHighScore = score;

        }

    }

    ////////
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
        HighsScoreSwitch = true;
    }

    public void DerayMoveKMGMs()
    {
        KMHH_TimeManager.gameStart = false;
        KMHH_TimeManager.gameFinish = false;


        SceneManager.LoadScene("KMGMs");
        HighsScoreSwitch = true;
    }

    public void KMHHExchangeToKumaCoin()　　//スコアからクマコイン作るよ    
    {

        exchangeToKumaCoin = (int)(Math.Round((KMHH_ScoreManager.totalScore) / 1000));

        oldTotalKumaCoinValue = PlayerPrefs.GetInt("KumaCoinValue", 0);

        newTotalKumaCoinValue = oldTotalKumaCoinValue + exchangeToKumaCoin;

        PlayerPrefs.SetInt("KumaCoinValue", newTotalKumaCoinValue);
        PlayerPrefs.Save();

        Debug.Log("今回のスコア→クマコイン:" + exchangeToKumaCoin);
        Debug.Log("前回までのクマコイン:" + oldTotalKumaCoinValue);
        Debug.Log("トータルのクマコイン:" + newTotalKumaCoinValue);



    }

}
