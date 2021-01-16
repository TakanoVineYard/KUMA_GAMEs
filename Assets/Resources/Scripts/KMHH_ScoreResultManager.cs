using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？
using static KMHH_ScoreManager;
using UnityEngine.SceneManagement; //シーン切り替え
using TMPro; //TextMeshPro用
using static KMGMs_SoundManager;

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

    TextMeshProUGUI resultMaxComboText;
    TextMeshProUGUI resultScoreText;
    TextMeshProUGUI resultHighScoreText;
    TextMeshProUGUI resultScoreExcellent;
    TextMeshProUGUI resultScoreGreat;
    TextMeshProUGUI resultScoreGood;
    TextMeshProUGUI resultScoreNotGood;
    TextMeshProUGUI resultScorePoor;
    TextMeshProUGUI resultScoreMiss;

    bool HighsScoreSwitch = false;

    // Start is called before the first frame update
    public void Start()
    {
        // スコアのロード
        KmhhHighScore = PlayerPrefs.GetInt("KMHH_HighScore", 0);
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


        resultMaxComboText.text =  "<bounce>" + KMHH_ScoreManager.maxCombo.ToString();
        resultScoreText.text = "<bounce>" + ((int)KMHH_ScoreManager.totalScore).ToString();
        resultScoreExcellent.text = "<bounce>" + KMHH_ScoreManager.scoreExcellent.ToString();
        resultScoreGreat.text = "<bounce>" + KMHH_ScoreManager.scoreGreat.ToString();
        resultScoreGood.text = "<bounce>" + KMHH_ScoreManager.scoreGood.ToString();
        resultScoreNotGood.text = "<bounce>" + KMHH_ScoreManager.scoreNotGood.ToString();
        resultScorePoor.text = "<bounce>" + KMHH_ScoreManager.scorePoor.ToString();
        resultScoreMiss.text = "<bounce>" + KMHH_ScoreManager.scoreMiss.ToString();

        HighsScoreSwitch = true;

        resultHighScoreMarkObj.SetActive(false);
    }
    public void Update()
    {

        if (HighsScoreSwitch)
        {


            KmhhHighScore = PlayerPrefs.GetInt("KMHH_HighScore", 0);

            KMHH_ScoreSave((int)KMHH_ScoreManager.totalScore);

            resultHighScoreText.text = "<bounce>" + KmhhHighScore.ToString();
            Debug.Log("ハイスコア:" + KmhhHighScore);
            HighsScoreSwitch = false;

        }
    }


    public void KMHH_ScoreSave(int score)
    {
        if (KmhhHighScore <= score)
        {
            // スコアを保存
            PlayerPrefs.SetInt("KMHH_HighScore", score);
            PlayerPrefs.Save();

            Debug.Log("ハイスコアセーブ" + score);

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

}
