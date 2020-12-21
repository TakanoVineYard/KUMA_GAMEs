using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使う
using static TimerTest;
using UnityEngine.SceneManagement; //シーン切り替え
using static CharacterTest;


public class TimerTest : MonoBehaviour
{

    //private static int minute = 0; //分
    private static float seconds = 0;　//秒
    private static float oldSeconds = 0; //前のUpdateのときの秒数

    public static bool GameStart;

    public static float getDeltaTime = 0; //時間経過取得の大元

    private Text CountTimer; //経過時間用

    public  AudioClip soundGameStart;
    public  AudioClip soundGameBGM;
    public AudioClip soundGameFinish;

    AudioSource GameAudioSource; //ゲームBGM

    public GameObject pauseButton;
    public bool PauseButton = false; //ゲーム一時停止

    public static bool gameFinish = false;
    public bool gameFinishTime = false;

    float gameSetTime = 10.0f;
    float gameTimeOffset = 0;

    //Start is called before the first frame update
    void Start()
    {

        //pauseButton = GameObject.Find("PauseButton");

        //minute = 0;
        seconds = 0;
        oldSeconds = 0;
        CountTimer = GetComponentInChildren<Text>(); //ゲーム時間用Textコンポーネント拾ってくるぜ
        CountTimer.enabled = false;　//
        GameAudioSource = GetComponent<AudioSource>(); //オーディオソースを引っ張る
        gameTimeOffset = getDeltaTime;
        gameFinish = false;
        gameFinishTime = false;
    }


    //Update is called once per frame
    void Update()
    {
        if (gameFinishTime == false) {

            getDeltaTime = Time.deltaTime;

        }

        if ((GameStart == true)&&(gameFinish == false))
        {
            if (CountTimer.enabled == false)
            {
                CountTimer.enabled = true;  //カウントの表示
                GameAudioSource.PlayOneShot(soundGameStart); //音再生
            } //開始時テキストの表示

            seconds += (getDeltaTime - gameTimeOffset);

            //↓制限時間を過ぎたら
            if (seconds > gameSetTime)
            {
                //minute++;
                //seconds = seconds - 60;
                GameStart = false;
                gameFinish = true;
            }
            //↓もし秒の数値が前回の秒数と違ったら(時間が経過してたら)テキストを更新
            if ((GameStart == true)&&((int)seconds != (int)oldSeconds))
            {
//                CountTimer.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
                CountTimer.text = ((int)seconds).ToString("00");
            }

            oldSeconds = seconds; //経過時間として現在の時間を上書く

        }

        if ((GameStart == false)&&(gameFinish == true))
        {

            Debug.Log("ゲームとまった");

            CountTimer.text = "Finish!!";

                        if(seconds != 0){
                GameAudioSource.PlayOneShot(soundGameFinish); //音再生
            }
            GamePose();



        }
    }


    public static void GameStartTrigger()
    {
        //minute = 0;
        oldSeconds = 0;
        GameStart = true;
    }

    public void GamePose()　//時間経過後ゲーム止める
    {
        
        getDeltaTime = 0;
        seconds = 0;  //秒数リセットしておく
        //MoveReset();
        //gameFinishTime = true;
        Invoke("DerayGameTitleLoadRun", 4.0f);

    }

    public void DerayGameTitleLoadRun()
    {
        SceneManager.LoadScene("Result");
    }
}
