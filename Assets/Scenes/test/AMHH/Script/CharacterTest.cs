using UnityEngine;
using System;
using System.Collections.Generic;
using static CountDownTimerTest;
using static TimerTest;
using static ScoreTest;


public class CharacterTest : MonoBehaviour
{
    public Animator CharaAnimator;　//アニメーター用変数
    public Animator ResultAnimator;　//アニメーター用変数
    public bool QuestionStatus = false; //出題状態かどうか
    public GameObject resultObj;  //ゲームオブジェクトResultを入れる用

    public bool GameStartTrigger = false; //ゲーム開始の許可用

    float span = 1.5f;  //待機出題までのスパン
    //public float elapsedTime;  //合計経過時間
    public float currentTime = 0.0f; //現在の時間

    //public float MoveResetSpan = 5.0f; //戻るまでのラグ
    
    public ScoreTest sr; //スコアテストスクリプト使えるように スコアリザルト用

    public ScoreTest tj; //スコアテストスクリプト使えるように タイムジャッジ用



    //public float startTime = 0.0f; //出題時点のカレントタイム
    public float endTime = 0.0f; //回答時のカレントタイム。差分で答えるまでにかかった時間を取る
    public float answerTime = 0.0f; //出題から回答までの時間をとる



    public void Start()
    {
        sr = GameObject.Find("score").GetComponent<ScoreTest>();

        resultObj = GameObject.Find("Result");  //シーン内からResultゲームオブジェクトを探してくる

        CharaAnimator = GetComponent<Animator>();　//このオブジェクトからアニメーターを取得
        ResultAnimator = resultObj.GetComponent<Animator>(); //シーンからアニメーターを取得


        //ResultTest rTest = resultObj.GetComponent<ResultTest>();

    }


    public void Update()
    {

        if(TimerTest.gameFinish == true){
            QuestionStatus = false;
        }


        if (CharaAnimator.GetBool("BackToIdle") == true)//待機戻りがオンだったら
        {
            
            CharaAnimator.SetBool("BackToIdle", false);  //オフにする
        }

        currentTime += getDeltaTime;  //経過時間を加える

        //Debug.Log("startTime"+startTime);
        //Debug.Log("endTime" + endTime);
        //Debug.Log(getDeltaTime);

        GameStartTrigger = GameStart;

        if (GameStartTrigger == true)
        {

            endTime += getDeltaTime;


            if (currentTime >= span)  //経過時間がスパンより大きくなったら実行
            {
                currentTime = 0f;   //現在の時間をリセット

                //もし出題状態じゃなかったら実行
                if ((QuestionStatus == false))
                {

                    MoveSelect(); //方向を選ぶ関数

                }
                //もし出題状態だったら実行

//                else if (QuestionStatus == true)
//              {
//
//              }
            }

            if (endTime > tj.timeJudgeRange[4])
            {
                
            ResultAnimator.SetBool("Incorrect",true);


                sr.AddResult(false);

                Debug.Log((tj.timeJudgeRange[4]) + "秒経過でミス");

                 Invoke("MoveReset", 0.5f); //しばらくしたら出題状態をやめて、アニメーターの状態をIdleに戻す。

            }

        }


    }

       // return CountDownTimerTest.GameStart;
 
    public void JudgeL()   //外から左ボタンが押されたときに実行
    {


        if (QuestionStatus == false) //出題状態じゃない限り、何も実行しないで戻る
        {
            //Debug.Log("りたーん");
            return;
        }


        if (CharaAnimator.GetBool("Left") == true)
        {
            //Debug.Log("左！あたり！");
            ResultAnimator.SetBool("Correct", true);


            sr.AddResult(true);
        }
        else
        {
            //ｓDebug.Log("左じゃないよハズレだよ！！");
            ResultAnimator.SetBool("Incorrect", true);

            sr.AddResult(false);

        }


        Invoke("MoveReset", 0.5f); //しばらくしたら出題状態をやめて、アニメーターの状態をIdleに戻す。
    }

    public void JudgeR()   //外から右ボタンが押されたときに実行
    {



        if (QuestionStatus == false) //出題状態じゃない限り、何も実行しないで戻る
        {
            //  Debug.Log("りたーん");
            return;
        }

        if (CharaAnimator.GetBool("Right") == true)
        {
            //Debug.Log("右！あたり！");
            ResultAnimator.SetBool("Correct", true);
            sr.AddResult(true);
        }
        else
        {
            //Debug.Log("右じゃないよハズレだよ！！");

            ResultAnimator.SetBool("Incorrect", true);
            sr.AddResult(false);
        }


        Invoke("MoveReset", 0.5f); //しばらくしたら出題状態をやめて、アニメーターの状態をIdleに戻す。

    }
    public void JudgeU()   //外から左ボタンが押されたときに実行
    {


        if (QuestionStatus == false) //出題状態じゃない限り、何も実行しないで戻る
        {
            //  Debug.Log("りたーん");
            return;
        }

        if (CharaAnimator.GetBool("Up") == true)
        {
            //Debug.Log("上！あたり！");
            ResultAnimator.SetBool("Correct", true);
            sr.AddResult(true);
        }
        else
        {
            // Debug.Log("上じゃないよハズレだよ！！");
            ResultAnimator.SetBool("Incorrect", true);
            sr.AddResult(false);

        }


        Invoke("MoveReset", 0.5f); //しばらくしたら出題状態をやめて、アニメーターの状態をIdleに戻す。
    }

    public void JudgeD()   //外から左ボタンが押されたときに実行
    {




        if (QuestionStatus == false) //出題状態じゃない限り、何も実行しないで戻る
        {
            //   Debug.Log("りたーん");
            return;
        }

        if (CharaAnimator.GetBool("Down") == true)
        {
            // Debug.Log("下！あたり！");
            ResultAnimator.SetBool("Correct", true);
            sr.AddResult(true);
        }
        else
        {
            //Debug.Log("下じゃないよハズレだよ！！");
            ResultAnimator.SetBool("Incorrect", true);
            sr.AddResult(false);
        }


        Invoke("MoveReset", 0.5f); //しばらくしたら出題状態をやめて、アニメーターの状態をIdleに戻す。
    }



    public void MoveSelect() //キャラの方向を選ぶ関数
    {

        QuestionStatus = true; //出題状態にする
        //startTime = 0;
        endTime = 0;

        

        switch (UnityEngine.Random.Range(0, 100) % 4)　//ランダムのあまりの数値で分岐。2で割ったあまりだから0か1
        {

            case 0:

                //Debug.Log("0");

                CharaAnimator.SetBool("Left",true);  //左トリガーを実行

                break;

            case 1:
                //Debug.Log("1");

                CharaAnimator.SetBool("Right", true);  //右トリガーを実行

                break;
            case 2:
                //Debug.Log("2");

                CharaAnimator.SetBool("Up", true);  //上トリガーを実行

                break;
            case 3:
                //Debug.Log("3");

                CharaAnimator.SetBool("Down", true);  //下トリガーを実行

                break;
        }

    }


    public void MoveReset() //出題状態をやめて、アニメーターの状態をIdleに戻す。
    {

        Debug.Log("むーぶりせっと");
        QuestionStatus = false;
        CharaAnimator.SetBool("Left", false);  //左トリガーをオフ
        CharaAnimator.SetBool("Right", false);  //右トリガーをオフ
        CharaAnimator.SetBool("Up", false);  //上トリガーをオフ
        CharaAnimator.SetBool("Down", false);  //下トリガーをオフ
        CharaAnimator.SetBool("BackToIdle", true);  //待機に戻るトリガーを実行

        ResultAnimator.SetBool("Correct", false); //　正解トリガーをオフ
        ResultAnimator.SetBool("Incorrect", false); //不正解トリガーをオフ



    }

    public float GetAnswerTime()
    {
         
        return (endTime);
    }


    public void IncCollectAnswer(){
            ResultAnimator.SetBool("Incorrect", true);
    }

}
