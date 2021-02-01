using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要
using TMPro; //TextMeshPro用

using static KMHH_TimeManager; //時間管理スクリプトを使う
using static KMHH_CharaAnimationManager;
using static KMHH_ScoreManager;//スコア管理スクリプトを使う
using static KMHH_SoundManager;


public class KMHH_PlayerInputManager : MonoBehaviour
{
    public int numOfBodyPart = 0; //　↑の変数の番号

    public string suffixBodyPartsName;　//末尾にいれるパーツ

    public static float countTime; //リセットまでの時間計測

    //デバッグ　正否文字表示
    public static GameObject Debug_AnserResultObj;
    public static TextMeshProUGUI Debug_AnserResultText;

    public static float recordAnserTime; //ボタン押されたタイミングのanserTimeを記録
    public static bool switchResetAnserResult = false; //リセットにいくためのスイッチ
    void Start()
    {

        Debug_AnserResultObj = GameObject.Find("Debug_AnserResult");
        Debug_AnserResultText = Debug_AnserResultObj.GetComponentInChildren<TextMeshProUGUI>();
        Debug_AnserResultText = Debug_AnserResultObj.GetComponentInChildren<TextMeshProUGUI>();
    }
////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 待機もどり処理まわし
    /// </summary>
    /// <returns></returns>   
    void Update(){


        if(switchResetAnserResult){
            countTime += Time.deltaTime;

            if(countTime>10.0f){
                ResetAnserResult();
            }
        }
    }
////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 正解んときの処理
    /// </summary>
    /// <returns></returns>   
public static void AnserResultCollect()
    {

    if(KMHH_TimeManager.editTimeScale <= 3.0f){ //速度頭打ち
    KMHH_TimeManager.editTimeScale += 0.025f;
        }
    
    KMHH_ScoreManager.AddAnserResult(true);     //不正解で回答結果更新

    //Debug_AnserResultText.text ="SEIKAI";
    KMHH_TimeManager.setEmotion(true);          //エモーションステート選びにいく

    KMHH_TimeManager.switchQuestion = false;　  //出題オフ

    switchResetAnserResult = true;              //Idle戻るまでの時間計測開始させる
    
}

////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 不正解んときの処理
    /// </summary>
    /// <returns></returns> 
public static void AnserResultIncorrect(){
    
    KMHH_TimeManager.editTimeScale =　1.0f; //間違えたらスピード下げ 
    //Debug_AnserResultText.text ="CHIGAU";
    KMHH_TimeManager.setEmotion(false);　       //エモーションステート選びにいく

    KMHH_TimeManager.switchQuestion = false;　  //出題オフ
    
    KMHH_ScoreManager.AddAnserResult(false);　  //不正解で回答結果更新
    switchResetAnserResult = true;              //Idle戻るまでの時間計測開始させる
    
}


////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 回答後、待機に戻る
    /// </summary>
    /// <returns></returns> 
public static void ResetAnserResult(){
    switchResetAnserResult = false;
    countTime = 0.0f;

    Debug_AnserResultText.text ="";
    KMHH_TimeManager.setIdle();
}

////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
    /// <summary>
    /// ボタン押されたときのanserTime
    /// </summary>
    /// <returns></returns>   
    public static float RecordAnserTime(){
        KMHH_TimeManager.recordAnserTime = KMHH_TimeManager.anserTime; //時間管理スクリプトから回答経過時間を引っ張る
        
        recordAnserTime = KMHH_TimeManager.recordAnserTime;　//代入

        Debug.Log("押した時間："+ recordAnserTime);
        return recordAnserTime;
    }


    /// <summary>
    /// 左ボタン押されたときの成否判断処理
    /// </summary>
    /// <returns></returns>   
    public void JudgeL()   //外から左ボタンが押されたときに実行
    {

        //Random数値のポーズの、セットされてるボディパーツに該当する結果が　L　かどうか

        if(KMHH_TimeManager.questionStatus){
            if (KMHH_CharaAnimationManager.resultCollectAnser == "L"){

                Debug.Log("せいかい");
                AnserResultCollect();
            }
            else{
                Debug.Log("ふせいかい");
                AnserResultIncorrect();
            }
        
        }
        else{
        }
    }
    public void JudgeUL()   //外から左ボタンが押されたときに実行
    {
        //Random数値のポーズの、セットされてるボディパーツに該当する結果が　UL　かどうか

        if(KMHH_TimeManager.questionStatus){
            if (KMHH_CharaAnimationManager.resultCollectAnser == "UL"){


                Debug.Log("せいかい");
                AnserResultCollect();
            }
            else{
                Debug.Log("ふせいかい");
                AnserResultIncorrect();
            }
        
        }
        else{
        }
    }
    public void JudgeDL()   //外から左ボタンが押されたときに実行
    {
        //Random数値のポーズの、セットされてるボディパーツに該当する結果が　DL　かどうか

        if(KMHH_TimeManager.questionStatus){
            if (KMHH_CharaAnimationManager.resultCollectAnser == "DL"){


                Debug.Log("せいかい");
                AnserResultCollect();
            }
            else{
                Debug.Log("ふせいかい");
                AnserResultIncorrect();
            }
        
        }
        else{
        }
    }  
    public void JudgeR()   //外から左ボタンが押されたときに実行
    {
        //Random数値のポーズの、セットされてるボディパーツに該当する結果が　R　かどうか

        if(KMHH_TimeManager.questionStatus){
            if (KMHH_CharaAnimationManager.resultCollectAnser == "R"){


                Debug.Log("せいかい");
                AnserResultCollect();
            }
            else{
                Debug.Log("ふせいかい");
                AnserResultIncorrect();
            }
        
        }
        else{
        }
    } 
    public void JudgeUR()   //外から左ボタンが押されたときに実行
    {
        //Random数値のポーズの、セットされてるボディパーツに該当する結果が　UR　かどうか

        if(KMHH_TimeManager.questionStatus){
            if (KMHH_CharaAnimationManager.resultCollectAnser == "UR"){


                Debug.Log("せいかい");
                AnserResultCollect();
            }
            else{
                Debug.Log("ふせいかい");
                AnserResultIncorrect();
            }
        
        }
        else{
        }
    }
    public void JudgeDR()   //外から左ボタンが押されたときに実行
    {
        //Random数値のポーズの、セットされてるボディパーツに該当する結果が　DR　かどうか

        if(KMHH_TimeManager.questionStatus){
            if (KMHH_CharaAnimationManager.resultCollectAnser == "DR"){


                Debug.Log("せいかい");
                AnserResultCollect();
            }
            else{
                Debug.Log("ふせいかい");
                AnserResultIncorrect();
            }
        
        }
        else{
        }
    } 
    public void JudgeU()   //外から左ボタンが押されたときに実行
    {
        //Random数値のポーズの、セットされてるボディパーツに該当する結果が　U　かどうか

        if(KMHH_TimeManager.questionStatus){
            if (KMHH_CharaAnimationManager.resultCollectAnser == "U"){


                Debug.Log("せいかい");
                AnserResultCollect();
            }
            else{
                Debug.Log("ふせいかい");
                AnserResultIncorrect();
            }
        
        }
        else{
        }
    }  
    public void JudgeD()   //外から左ボタンが押されたときに実行
    {
        //Random数値のポーズの、セットされてるボディパーツに該当する結果が　D　かどうか

        if(KMHH_TimeManager.questionStatus){
            if (KMHH_CharaAnimationManager.resultCollectAnser == "D"){


                Debug.Log("せいかい");
                AnserResultCollect();
            }
            else{
                Debug.Log("ふせいかい");
                AnserResultIncorrect();
            }
        
        }
        else{
        }
    } 


}
