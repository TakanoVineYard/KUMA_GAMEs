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

    public GameObject resultMaxComboObj;
    public GameObject resultScoreTextObj;
    public GameObject resultScoreExcellentObj;
    public GameObject resultScoreGreatObj;
    public GameObject resultScoreGoodObj;
    public GameObject resultScoreNotGoodObj;
    public GameObject resultScorePoorObj;
    public GameObject resultScoreMissObj;

    TextMeshProUGUI resultMaxComboText;
    TextMeshProUGUI resultScoreText;
    TextMeshProUGUI resultScoreExcellent;
    TextMeshProUGUI resultScoreGreat;
    TextMeshProUGUI resultScoreGood;
    TextMeshProUGUI resultScoreNotGood;
    TextMeshProUGUI resultScorePoor;
    TextMeshProUGUI resultScoreMiss;

    // Start is called before the first frame update
    public void Start()
    {
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
    }

    public void DerayMoveKMGMs()
    {
        KMHH_TimeManager.gameStart = false;
        KMHH_TimeManager.gameFinish = false;

        
            SceneManager.LoadScene("KMGMs");
    }

}
