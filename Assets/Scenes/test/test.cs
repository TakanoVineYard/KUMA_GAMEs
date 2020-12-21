using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public static bool status = false;      //ステータスのtrue,falseきりかえ

    public static bool switchAtime = false; //条件Aのスイッチ
    public static bool switchBtime = false; //条件Bのスイッチ

    public float timeA = 1.0f;              //条件Aを達成に必要な秒数　1s

    public float timeB = 3.0f;              //条件Bを達成に必要な秒数　3s

    public float timeCount = 0.0f;          //時間計測

    public string  statusResult;           //ステータスの状態（デバッグモニタ用にintで記録）
    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;        //フレームごとの時間足し
        Debug.Log("timeCount:"+timeCount);　

// timeAの秒数経過後にstatusをTrue、TimeB秒経過後にstatusをfalseにしたい


        if ((timeCount >= timeA)&&(switchAtime==true)){ //１秒以上かつ、Aのスイッチが入ってたら
            switchAtime=false;                          //Aのスイッチ切る
            status = true;                              //ステータスをtrueにする
            timeCount = 0.0f;                           //時間計測のリセット
        }

        if ((timeCount >= timeB)&&(switchBtime==true)){//３秒以上かつ、Bのスイッチが入ってたら
            switchBtime=false;                          //Bのスイッチ切る
            status = false;                             //ステータスをfalseにする
            timeCount = 0.0f;                           //時間計測のリセット
        }

        if (status == true){                            //もしstatusがtrueなら
            statusResult = "true";
            Debug.Log("status true:"+timeCount);
            //次はfalseにするために
            switchBtime = true;                         //Bスイッチを入れて、３秒経過に備える

        }
        else{
            statusResult = "false";
            Debug.Log("status false:"+timeCount);       //もしstatusがfalseなら

            //次はtrueにするために
            switchAtime = true;                         //Aスイッチを入れて、1秒経過に備える
        }
    }

    public void pushedButton(){
        Debug.Log("きりかえ");
        if (status == true){             //もしstatusがtrueなら
            switchBtime=false;                          //Bのスイッチ切る
            status = false;                             //ステータスをfalseにする
            timeCount = 0.0f;                           //時間計測のリセット
        }
        else{                            //もしstatusがtrueなら
            switchAtime=false;                          //Aのスイッチ切る
            status = true;                              //ステータスをtrueにする
            timeCount = 0.0f;                           //時間計測のリセット
        }
    }
}
