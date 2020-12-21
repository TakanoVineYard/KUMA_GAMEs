using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //テキスト使うなら必要
using UnityEngine;
using static UnityEngine.GameObject;

public class ScoreTest : MonoBehaviour
{
    public  int comboCountNum = 0;
    const float baseScore = 100.0f;
    public static float totalScore = 0.0f;


    public Text comboText;
    public Text scoreText;

    public float[] timeJudgeRange = new float[5]; //回答までの時間区分け
    public float[] timeJudgeValue = new float[6];　//回答までの時間による係数

    public CharacterTest at;

    public bool successResult;

    //テキストを上書いて、Great、Goodなどやってたが、本番ではPrefabごとに作るので不要
    private GameObject ctj;


    public static int maxCombo = 0;
    public static int scoreGreat = 0;
    public static int scoreGood = 0;
    public static int scoreBetter = 0;
    public static int scoreNotBad = 0;
    public static int scoreBad = 0;
    public static int scoreMiss = 0;


    /// <summary>
    /// 成功したか失敗したかを、ゲームを管理するクラスからこいつへ教えてあげる
    /// </summary>
    /// <param name="success"></param>
    /// 

    public void Start()
    {
        //コンボカウントしてるオブジェクトと、スコア表示のオブジェクトの取得
        GameObject comboTextObj = GameObject.Find("comboCount");
        GameObject scoreTextObj = GameObject.Find("score");

        //テキスト乗っ取り
        comboText = comboTextObj.GetComponentInChildren<Text>();
        scoreText = scoreTextObj.GetComponentInChildren<Text>();

        Debug.Log(comboText);
        Debug.Log(scoreText);

        //他のスクリプトの要素を、ゲームオブジェクトのコンポーネント取得で操作
        at = GameObject.Find("ThendBear").GetComponent<CharacterTest>();

        //正解時間判定でテキストを上書く用のゲームオブジェクトを取得
        //テキストを上書いて、Great、Goodなどやってたが、本番ではPrefabごとに作るので不要
        ctj = GameObject.Find("correctTimeJudge"); 

    }


    public void Update()
    {

        //ゲーム始まってないし、終わってない間　リセット
        if ((TimerTest.GameStart == false)&&(TimerTest.gameFinish == false )){

            totalScore = 0;
            comboCountNum = 0;
            maxCombo = 0;
            scoreGreat = 0;
            scoreGood = 0;
            scoreBetter = 0;
            scoreNotBad = 0;
            scoreBad = 0;
            scoreMiss = 0;  

        }

    }
    /// <summary>
    /// 他から呼び出される、　正解かどうかの引数を受け取って、
    ///コンボの加減算やマックスコンボの更新、
    ///スコアとコンボ数の表示更新などを行う
    /// </summary>
    /// <returns>trueかfalseを受け取る</returns>
    public void AddResult(bool answer)
     {


        float answerTimeRange = at.GetAnswerTime();

            if (answer)
            {
                comboCountNum++;
               // Debug.Log(GetScore());

            if(comboCountNum > maxCombo)
            {
                maxCombo = comboCountNum; //マックスコンボの更新
            }

            }
            else if ((answer)&&(answerTimeRange > timeJudgeRange[3]))  //成功だが3秒以上かかっててもだめ
            {
            comboCountNum = 0;

            }
            else
            {
                comboCountNum = 0;

            }
            
        scoreText.text = "スコア:" + GetScore(answerTimeRange);
        comboText.text = comboCountNum.ToString() + "コンボ";
        //Debug.Log(comboCountNum + "コンボ");
        //Debug.Log("スコア"+GetScore());
    }

    /// <summary>
    /// 現状でのスコアをゲッツ
    /// </summary>
    /// <returns>コンボによる倍率をかけた値を返す</returns>
    public float GetScore(float pastAnswerTime)
    {

        //係数をいれる
        float coefficient = 0.0f;

       if ((pastAnswerTime <= timeJudgeRange[0]) && (successResult))
        {
            coefficient = timeJudgeValue[0];
            Debug.Log("Great!" + timeJudgeValue[0]);
            ctj.GetComponent<TextMesh>().text = "Great!";
            scoreGreat += 1;

        }
       else if ((pastAnswerTime > timeJudgeRange[0]) && (pastAnswerTime <= timeJudgeRange[1]) && (successResult))
        {
            coefficient = timeJudgeValue[1];
            Debug.Log("Good" + timeJudgeValue[1]);
            ctj.GetComponent<TextMesh>().text = "Good!";
            scoreGood += 1;

        }
        else if ((pastAnswerTime > timeJudgeRange[1]) && (pastAnswerTime <= timeJudgeRange[2]) && (successResult))
        {
            coefficient = timeJudgeValue[2];
            Debug.Log("better" + timeJudgeValue[2]);
            ctj.GetComponent<TextMesh>().text = "better!";
            scoreBetter += 1;

        }
        else if ((pastAnswerTime > timeJudgeRange[2]) && (pastAnswerTime <= timeJudgeRange[3]) && (successResult))
        {
            coefficient = timeJudgeValue[3];
            ctj.GetComponent<TextMesh>().text = "NotBad";
            Debug.Log("NotBad");
            scoreNotBad += 1;

        }
        else if ((pastAnswerTime > timeJudgeRange[3]) && (pastAnswerTime <= timeJudgeRange[4]) && (successResult))
        {
            coefficient = timeJudgeValue[4];
            ctj.GetComponent<TextMesh>().text = "Bad";

            Debug.Log("Bad");
            scoreBad += 1;

        }

        //回答時間が指定時間より長かったら
        else if (pastAnswerTime > timeJudgeRange[4])
        {
            coefficient = timeJudgeValue[5];

            Debug.Log("miss");
            ctj.GetComponent<TextMesh>().text = "miss";
            //コンボ数も降り出し
            comboCountNum = 0;

            scoreMiss += 1;

        }
        at.endTime = 0;

        if (comboCountNum == 0){
            return totalScore;
        }
        else
        {
            totalScore += baseScore * coefficient * comboCountNum;
            return totalScore;

        }
    }


}
