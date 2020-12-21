using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？
using static TimerTest;
using static SoundTest;

public class CountDownTimerTest : MonoBehaviour
{
    public float seconds = 0;　//秒
    float countDownTimeOffset = 0;
    public int CountDownMin = 3; //カウントダウン整数
    public float CountDownSpan = 1.0f; //カウントダウンの秒スパン

    public Text CountDownTimer; //カウントダウン数値をいれるテキスト
   



    // Start is called before the first frame update
    void Start()
    {

        //GameAudioSource.PlayOneShot(soundCountDown);
        seconds = 0;
        countDownTimeOffset = getDeltaTime;
        CountDownMin = 3;
        CountDownTimer = GetComponentInChildren<Text>(); //カウントダウン用Textコンポーネント拾ってくるぜ  
    }

    // Update is called once per frame
    public void Update()
    {


        //Debug.Log("カウントダウン側経過時間"+getDeltaTime);
        if (GameStart == false)
        {

            seconds += (getDeltaTime - countDownTimeOffset);

            //1秒でリセット

            if (seconds > CountDownSpan)
            {
                //Debug.Log(CountDownSpan+"秒たった");
                CountDownMin -= 1;
                seconds = 0; 

            }

            //↓もし秒の数値が前回の秒数と違ったら(時間が経過してたら)テキストを更新
            //if ((int)seconds != (int)oldSeconds)
            //{
                CountDownTimer.text = CountDownMin.ToString();

            //}

            if (CountDownMin <= 0)
            {
                CountDownTimer.text = "Start！";

 
                
                GameStartTrigger();
                Invoke("OffActiveStartText", 1); //一秒たったら消す
            }

        }
    }

    void OffActiveStartText()
    {
        CountDownTimer.enabled = false;
        //this.gameObject.SetActive (false);
        ResetCountDown();

    }

    void ResetCountDown(){
        CountDownMin = 3;
    }

}
