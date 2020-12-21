using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？
using static ScoreTest;
using UnityEngine.SceneManagement; //シーン切り替え

public class ResultJudgeTest : MonoBehaviour
{

    public GameObject resultMaxComboObj;
    public GameObject resultScoreTextObj;
    public GameObject resultScoreGreatObj;
    public GameObject resultScoreGoodObj;
    public GameObject resultScoreBetterObj;
    public GameObject resultScoreNotBadObj;
    public GameObject resultScoreBadObj;
    public GameObject resultScoreMissObj;





    // Start is called before the first frame update
    public void Start()
    {
        resultMaxComboObj = GameObject.Find("ResultMaxCombo");
        resultScoreTextObj = GameObject.Find("ResultScore");
        resultScoreGreatObj = GameObject.Find("ResultGreat");
        resultScoreGoodObj = GameObject.Find("ResultGood");
        resultScoreBetterObj = GameObject.Find("ResultBetter");
        resultScoreNotBadObj = GameObject.Find("ResultNotBad");
        resultScoreBadObj = GameObject.Find("ResultBad");
        resultScoreMissObj = GameObject.Find("ResultMiss");



        Text resultMaxComboText = resultMaxComboObj.GetComponent<Text>();
        Text resultScoreText = resultScoreTextObj.GetComponent<Text>();
        Text resultScoreGreat = resultScoreGreatObj.GetComponent<Text>();
        Text resultScoreGood = resultScoreGoodObj.GetComponent<Text>();
        Text resultScoreBetter = resultScoreBetterObj.GetComponent<Text>();
        Text resultScoreNotBad = resultScoreNotBadObj.GetComponent<Text>();
        Text resultScoreBad = resultScoreBadObj.GetComponent<Text>();
        Text resultScoreMiss = resultScoreMissObj.GetComponent<Text>();

        resultMaxComboText.text = maxCombo.ToString() + "コンボ!";
        resultScoreText.text = "スコア:" + totalScore.ToString();
        resultScoreGreat.text = "Great:" + scoreGreat.ToString();
        resultScoreGood.text = "Good:" + scoreGood.ToString();
        resultScoreBetter.text = "Better:" + scoreBetter.ToString();
        resultScoreNotBad.text = "NotBad:" + scoreNotBad.ToString();
        resultScoreBad.text = "Bad:" + scoreBad.ToString();
        resultScoreMiss.text = "Miss:" + scoreMiss.ToString();

    }

// Update is called once per frame
void Update()
    {
        
    }

    public void ShowResult()
    {
        

    }

    public void TapToBackTitleButton()
    {
        Invoke("DerayGameLoadRun", 1);

    }

    public void DerayGameLoadRun()
    {

        SceneManager.LoadScene("MainTitle");
    }

}
