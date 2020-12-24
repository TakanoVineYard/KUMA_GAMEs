using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？

//using static KMHH_ScoreManager; //スコアスクリプトを使う
//using static KMHH_CharaAnimationManager; //キャラのアニメーション管理を使う
using static KMHH_PlayerInputManager;

using UnityEngine.SceneManagement; //シーン切り替え

using static KMGMs_SoundManager;

using TMPro; //TextMeshPro用

/// <summary>
/// ゲーム内の時間にまつわる操作を管理する
/// </summary>
/// <returns></returns> 
public class KMHH_TimeManager : MonoBehaviour
{



    public static bool debugTextSwitch = true; //デバッグテキストのオンオフ


    public static bool switchStartMethod = true; //ゲーム自体開始のスイッチ
    public static float getDeltaTime = 0.0f; //時間経過取得の大元
    public static float gameCurrentTime = 0.0f; //現在の時間
    public float gameStandbyTime = 1.0f; //スタンバイの時間
    float gameTimePast = 0.0f; //時間の経過
    int gameTimePastInt = 0;  //時間の経過のInt化
    float gameFinishTime = 0.0f; //ゲーム終了時の時間を記録
    public static float anserTime = 0.0f; //回答時のカレントタイム。
    public static float recordAnserTime = 0.0f; //回答時のカレントタイム。


    float idleTime = 0.0f; //待機時のカレントタイム。


    public static bool gameStart = false; //ゲームがスタートしているかの判定
    public static bool gameFinish = false; //ゲームが終了しているかの判定

    public static float editTimeScale = 1.0f; //キャラの動き時間のスケール

    public static bool questionStatus = false; //出題状態かどうか
    public float kmhhQuestionSpan = 5.0f;  //出題時間のスパン
    public float kmhhIdleSpan = 5.0f;  //　キャラクターの待機状態のスパン

    public static bool switchIdle = false; //条件 Idleのスイッチ
    public static bool switchQuestion = false; //条件 Questionのスイッチ



    public static int questionNumOfTimes = 0;  //出題回数

    public float gameSetTime = 100.0f; //ゲームが終了するまでの時間

    GameObject upDateGameTimerObj; //ゲームタイマーオブジェクト入れ
    public Text upDateGameTimerText; //ゲームタイマー数値をいれるテキスト

    public static GameObject debugGameTimerObj; //デバッグ用タイマーオブジェクト入れ
    public static Text debugGameTimeText; //デバッグ用タイマーオブジェクトテキスト入れ


    public AudioSource[] kmhh_AudioSources; //リザルト音源

    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    //カウントダウン関連変数
    //     GameObject countDownEffObj_3; //カウントダウン3エフェクトプレハブ入れ
    //     GameObject countDownEffObj_2; //カウントダウン2エフェクトプレハブ入れ
    //     GameObject countDownEffObj_1; //カウントダウン1エフェクトプレハブ入れ
    //     GameObject countDownEffObj_0; //カウントダウン0エフェクトプレハブ入れ
    //    GameObject countDownEffObj_Fin; //カウントダウンフィニッシュエフェクトプレハブ入れ
    public GameObject countDown_Obj; //カウントダウンプレハブの大元
    public Animator countDown_Animator;
    GameObject GameSceneChangeWallObj; //画面遷移エフェクトプレハブ入れ
    bool countDownStartTrigger = true;
    bool countDownTrigger3 = false; //カウントダウンのトリガー
    bool countDownTrigger2 = false; //カウントダウンのトリガー
    bool countDownTrigger1 = false; //カウントダウンのトリガー

    [SerializeField] public static Animator KMHH_GameSceneChangeWallAnimator; //リザルトアニメーター

    [SerializeField] public static Animator KMHH_countDownEffAnimator; //リザルトアニメーター

    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////

    //デバッグ　スピードアップしない
    bool debugSpeedUpONOFF = true;
    public TextMeshProUGUI debugSpeedUpONOFFText;

    //public GameObject kmhh_CAM_Obj;

    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    // Start is called before the first frame update

    public GameObject kmhhSkyDomeObj; //ゲーム中のBGMMaterialげっと

    public Material[] mat_KMHHSkyDome;
    int dayHourNum; //何時か拾う
                    ////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////
    void Start()
    {

        Debug.Log("さいしょのようい");

        getDeltaTime = 0.0f;
        Time.timeScale = 1.0f;
        questionNumOfTimes = 0;


        //        countDownEffObj_3 = GameObject.Find("eff_KMHH_CountDown_3");
        //        countDownEffObj_2 = GameObject.Find("eff_KMHH_CountDown_2");
        //        countDownEffObj_1 = GameObject.Find("eff_KMHH_CountDown_1");
        //        countDownEffObj_0 = GameObject.Find("eff_KMHH_CountDown_Start");
        //        countDownEffObj_Fin = GameObject.Find("eff_KMHH_CountDown_Finish");
        GameSceneChangeWallObj = GameObject.Find("eff_GameSceneChangeWall");


        upDateGameTimerObj = GameObject.Find("ui_GameTimer"); //ゲーム時間経過用オブジェクト拾ってくるぜ  

        upDateGameTimerText.text = gameSetTime.ToString(); //　時間制限をテキスト更新


        debugGameTimerObj = GameObject.Find("Debug_CountTimer");

        debugGameTimeText = debugGameTimerObj.GetComponentInChildren<Text>();


    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// ゲームの時間進行いろいろ。カウントダウンもやっちゃう 
    /// </summary>
    /// <returns></returns>   
    // Update is called once per frame
    public void Update()
    {
        debugGameTimeText.text = "Debug Info" + "\n" +
        "gameStart:" + gameStart + "\n" +
        "gameFinish:" + gameFinish + "\n" +
        "getDeltaTime:" + getDeltaTime.ToString("f2") + "\n" +
        "Q Speed:" + editTimeScale + "\n" +
        "-----------------------\n" +
        "Past Time:" + gameTimePast.ToString("f2") + "\n" +
        "Q NumOfTimes:" + questionNumOfTimes + "\n" +
        "Q Status:" + questionStatus + "\n" +
        "-----------------------\n" +
        "Q Span:" + kmhhQuestionSpan + "\n" +
        "Q Switch:" + switchQuestion + "\n" +
        "Anser Time:" + anserTime.ToString("f2") + "\n" +
        "-----------------------\n" +
        "Idle Span:" + kmhhIdleSpan + "\n" +
        "Idle Switch:" + switchIdle + "\n" +
        "Idle Time:" + idleTime.ToString("f2") + "\n";

        /*
        debugGameTimeText.text = "でばっぐ情報" +"\n" +
        "gameStart:" + gameStart + "\n" +
        "gameFinish:" + gameFinish + "\n"+
        "getDeltaTime:" + getDeltaTime.ToString()+"f2" +"\n"+
        "出題速度:" + editTimeScale +  "\n" +
        "ゲーム経過時間:" + gameTimePast.ToString("f2") +  "\n" +
        "出題回数:" + questionNumOfTimes + "\n" +
        "出題状態:"+ questionStatus  + "\n"+
        "-----------------------\n" +
        "出題時間のスパン:" + kmhhQuestionSpan  + "\n" +
        "出題スイッチ:"+ switchQuestion + "\n"+
        "回答時間:" + anserTime.ToString("f2")  + "\n" +
        "-----------------------\n" +
        "アイドルのスパン:" + kmhhIdleSpan  + "\n" +
        "待機スイッチ:"+ switchIdle + "\n"+
        "待機時間:" + idleTime.ToString("f2")  + "\n";
        */
        ///////////////////////////////////////////////////////////////////

        if ((switchStartMethod == true) && (gameFinish == false))
        {

            dayHourNum = System.DateTime.Now.Hour;

            Debug.Log(dayHourNum + "時なう");


            //今何時?
            if ((dayHourNum > 6) && (dayHourNum <= 16))
            {
                kmhhSkyDomeObj.GetComponent<Renderer>().sharedMaterial = mat_KMHHSkyDome[0];
            }
            else if ((dayHourNum > 16) && (dayHourNum <= 18))
            {
                kmhhSkyDomeObj.GetComponent<Renderer>().sharedMaterial = mat_KMHHSkyDome[1];
            }
            else
            {
                kmhhSkyDomeObj.GetComponent<Renderer>().sharedMaterial = mat_KMHHSkyDome[2];

            }


            countDown_Obj = GameObject.Find("ui_KMHH_CountDown_Obj");
            countDown_Animator = countDown_Obj.GetComponentInChildren<Animator>();

            Debug.Log("Updateのなかのさいしょのようい");
            switchStartMethod = false; //ゲーム自体開始のスイッチ
            getDeltaTime = 0.0f; //時間経過取得の大元
            gameCurrentTime = 0.0f; //現在の時間
            gameStandbyTime = 1.0f; //スタンバイの時間
            gameTimePast = 0.0f; //時間の経過
            gameTimePastInt = 0;  //時間の経過のInt化
            gameFinishTime = 0.0f; //ゲーム終了時の時間を記録
            anserTime = 0.0f; //回答時のカレントタイム。
            recordAnserTime = 0.0f; //回答時のカレントタイム。
            idleTime = 0.0f; //待機時のカレントタイム。
            gameStart = false; //ゲームがスタートしているかの判定
            gameFinish = false; //ゲームが終了しているかの判定
            editTimeScale = 1.0f; //キャラの動き時間のスケール
            questionStatus = false; //出題状態かどうか
            switchIdle = false; //条件 Idleのスイッチ
            switchQuestion = false; //条件 Questionのスイッチ
            questionNumOfTimes = 0;  //出題回数

            Time.timeScale = 1.0f;
            debugSpeedUpONOFF = true;


            countDownStartTrigger = true;

            KMHH_CharaAnimationManager.ChangeQuestionBodyParts();

            //            countDownEffObj_3 = GameObject.Find("eff_KMHH_CountDown_3");
            //            countDownEffObj_2 = GameObject.Find("eff_KMHH_CountDown_2");
            //            countDownEffObj_1 = GameObject.Find("eff_KMHH_CountDown_1");
            //            countDownEffObj_0 = GameObject.Find("eff_KMHH_CountDown_Start");
            //            countDownEffObj_Fin = GameObject.Find("eff_KMHH_CountDown_Finish");
            GameSceneChangeWallObj = GameObject.Find("eff_SceneChange");


            KMHH_GameSceneChangeWallAnimator = GameSceneChangeWallObj.GetComponentInChildren<Animator>();  //シーンチェンジアニメーター


            upDateGameTimerObj = GameObject.Find("ui_GameTimer"); //ゲーム時間経過用オブジェクト拾ってくるぜ  

            upDateGameTimerText.text = gameSetTime.ToString(); //　時間制限をテキスト更新


            debugGameTimerObj = GameObject.Find("Debug_CountTimer");

            debugGameTimeText = debugGameTimerObj.GetComponentInChildren<Text>();

            debugTextSwitch = true;
            DebugTextOnOff();

        }

        getDeltaTime += Time.deltaTime;


        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        //カウントダウン中
        if ((gameStart == false) && (gameFinish == false))
        {

            if (getDeltaTime < 0.1f)
            {
                if (countDownStartTrigger)
                {
                    setIdle();
                    countDownStartTrigger = !countDownStartTrigger;
                }
                //KMHH_CharaAnimationManager.hideBodyParts();


                //KMHH_CharaAnimationManager.ChangeQuestionBodyParts();
                KMHH_CharaAnimationManager.KMHH_CharaAnimator.SetBool("goToIdle", false);

                //                countDownEffObj_3.SetActive (false);            
                //                countDownEffObj_2.SetActive (false);
                //                countDownEffObj_1.SetActive (false);
                //                countDownEffObj_0.SetActive (false);
                //                countDownEffObj_Fin.SetActive (false);
                //                GameSceneChangeWallObj.SetActive (false);
            }
            if ((getDeltaTime >= gameStandbyTime) && (getDeltaTime < gameStandbyTime + 1.0f))
            {
                if (countDownTrigger3 == false)
                {
                    if (getDeltaTime != gameTimePast)
                    {
                        countDownTrigger3 = true;
                        Debug.Log("3");
                        countDown_Animator.CrossFadeInFixedTime("anm_UI_KMHH_CountDown3", 0.0f);
                        //countDownEffObj_3.SetActive (true);
                    }
                }
            }
            if ((getDeltaTime >= gameStandbyTime + 1.0f) && (getDeltaTime < gameStandbyTime + 2.0f))
            {
                if (countDownTrigger2 == false)
                {
                    if (getDeltaTime != gameTimePast)
                    {
                        countDownTrigger2 = true;
                        Debug.Log("2");
                        countDown_Animator.CrossFadeInFixedTime("anm_UI_KMHH_CountDown2", 0.0f);
                        //countDownEffObj_3.SetActive (false);
                        //countDownEffObj_2.SetActive (true);
                    }
                }
            }
            if ((getDeltaTime >= gameStandbyTime + 2.0f) && (getDeltaTime < gameStandbyTime + 3.0f))
            {
                if (countDownTrigger1 == false)
                {
                    if (getDeltaTime != gameTimePast)
                    {
                        countDownTrigger1 = true;
                        Debug.Log("1");
                        countDown_Animator.CrossFadeInFixedTime("anm_UI_KMHH_CountDown1", 0.0f);
                        //countDownEffObj_2.SetActive (false);
                        //countDownEffObj_1.SetActive (true);
                    }
                }
            }
            if (getDeltaTime >= gameStandbyTime + 3.0f)
            {
                gameStart = true;　//ゲーム開始状態にする
                Debug.Log("げーむすたーと");
                countDown_Animator.CrossFadeInFixedTime("anm_UI_KMHH_CountDownStart", 0.0f);
                gameTimePast = 0;
                questionNumOfTimes = 0;

                switchQuestion = true;


                //countDownEffObj_1.SetActive (false);
                //countDownEffObj_0.SetActive (true); 


                Invoke("CountDownObjHide", 1.5f);   // カウントダウン全部消す
                setQuestion();



                kmhh_AudioSources[0].pitch = Time.timeScale;
                kmhh_AudioSources[1].pitch = Time.timeScale;
                kmhh_AudioSources[2].pitch = Time.timeScale;
                kmhh_AudioSources[3].pitch = Time.timeScale;
                kmhh_AudioSources[4].pitch = Time.timeScale;
            }
            gameTimePast = getDeltaTime; //経過時間として現在の時間を上書く
        }
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        //ゲーム開始。ゲームが終わってないとき,ゲーム中の時間を記録
        if ((gameStart == true) && (gameFinish == false))
        {
            //デバッグ　スピードあげない
            if (debugSpeedUpONOFF == true)
            {
                Time.timeScale = editTimeScale;
            }
            else if(debugSpeedUpONOFF == false)
            {
                Time.timeScale = 1.0f;
            }

            gameCurrentTime += (Time.deltaTime / editTimeScale); //ゲーム時間を更新

            gameTimePast = gameCurrentTime; //経過時間として現在の時間を上書く
            gameTimePastInt = (int)gameTimePast; //↑整数化



            upDateGameTimerText.text = (((gameSetTime - gameTimePastInt).ToString()).PadLeft(2, '0')); //時間文字列更新

            ////////////////////////////////////////////////////////////////////
            //待機スイッチ入ってたら待機の秒数計測
            if (switchIdle)
            {
                idleTime += Time.deltaTime;
            }

            //回答スイッチ入ってたら回答の秒数計測
            if (switchQuestion)
            {
                anserTime += Time.deltaTime;
            }
            ////////////////////////////////////////////////////////////////////

            //↓制限時間を過ぎたらゲーム開始をfalse,ゲーム終了をtrue
            if (gameTimePast > gameSetTime)
            {
                Debug.Log("しゅうりょう");
                questionStatus = false;
                gameFinishTime = gameTimePast; //ゲーム終了時の時間を記録
                GameFinish();
                return;
            }
            ////////////////////////////////////////////////////////////////////

            if (idleTime > kmhhIdleSpan)
            {
                Debug.Log("待機スパンすぎた");
                setQuestion();

            }
            if (anserTime > kmhhQuestionSpan)
            {
                Debug.Log("回答スパンすぎた");
                if (questionStatus)
                {
                    setTimeOver();
                }
                //setIdle();

            }

        }
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        //ゲームが終わったとき,終了の処理        
        if ((gameStart == false) && (gameFinish == true))
        {
            //countDownEffObj_Fin.SetActive (true);

        }
    } //Update()ここまで
      ////////////////////////////////////////////////////////////////////
      ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// ゲーム開始フラグ建てる
    /// </summary>
    /// <returns></returns> 
    public void GameStartTrigger()
    {
        anserTime = 0.0f;
        Debug.Log("げーむすたーと");
        gameTimePast = 0;
        questionNumOfTimes = 0;
        gameStart = true;　//ゲーム開始状態にする
        Invoke("CountDownObjHide", 1.5f);   // カウントダウン全部消す
        KMHH_CharaAnimationManager.KMHH_CharaAnimator.SetBool("questionState", true);

    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////   
    /// <summary>
    /// カウントダウン全部消す 
    /// </summary>
    /// <returns></returns> 
    public void CountDownObjHide()
    {
        //countDownEffObj_3.SetActive (false);            
        //countDownEffObj_2.SetActive (false);
        //countDownEffObj_1.SetActive (false);
        //countDownEffObj_0.SetActive (false);
    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// ゲームが終わったとき,終了の処理 
    /// </summary>
    /// <returns></returns>   
    public void GameFinish()
    {
        editTimeScale = 1.0f; //終わったから速度戻す
        Time.timeScale = editTimeScale;
        gameStart = false;
        gameFinish = true;
        switchStartMethod = true;
        Debug.Log("ゲームとまった");

        //GameSceneChangeWallObj.SetActive (true);

        countDown_Animator.CrossFadeInFixedTime("anm_UI_KMHH_GameFinish", 0.0f);
        KMHH_GameSceneChangeWallAnimator.CrossFadeInFixedTime("anm_Eff_ChangeSceneClose", 0.0f);
        setFinish();

        Invoke("DerayGameTitleLoadRun", 4.0f);   // カウントダウン全部消す 
    }
    public void DerayGameTitleLoadRun()
    {
        SceneManager.LoadScene("KMHH_Result");
    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// タイムオーバー処理
    /// </summary>
    /// <returns></returns> 
    public void setTimeOver()
    {
        KMHH_ScoreManager.comboCountNum = 0; //コンボカウントのリセット　時間経過によるもの
        KMHH_PlayerInputManager.AnserResultIncorrect();
        anserTime = 0.0f;
        questionStatus = false;
        switchQuestion = false;
        switchIdle = false;

    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// クエスチョンステートにいく
    /// </summary>
    /// <returns></returns> 
    public void setQuestion()
    {
        idleTime = 0.0f;
        questionStatus = true;

        switchIdle = false;
        switchQuestion = true;


        Debug.Log("すてーと選びにいこかな" + questionStatus);
        KMHH_CharaAnimationManager.ChangeCharaState(); //キャラのステート変えるやつ
        questionNumOfTimes = questionNumOfTimes + 1;　//出題回数増やす
    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 待機にいく
    /// </summary>
    /// <returns></returns> 
    public static void setIdle()

    {
        if (switchStartMethod)
        {
            return;
        }

        anserTime = 0.0f;
        questionStatus = false;
        switchIdle = true;
        switchQuestion = false;

        Debug.Log("あいどるすてーと選びにいこかな");
        KMHH_CharaAnimationManager.ChangeCharaStateToIdle(); //キャラのステート変えるやつ　待機

    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// エモーションステートにいく
    /// </summary>
    /// <returns>成否で分岐</returns> 
    public static void setEmotion(bool anserResult)
    {
        questionStatus = false;
        switchIdle = false;
        switchQuestion = false;

        KMHH_CharaAnimationManager.ChangeCharaStateToEmotion(anserResult); //キャラのステート変えるやつ　待機

    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// フィニッシュステートにいく
    /// </summary>
    /// <returns></returns> 
    public void setFinish()
    {
        anserTime = 0.0f;
        questionStatus = false;
        switchIdle = false;
        switchQuestion = false;
        KMHH_CharaAnimationManager.ChangeCharaStateToFinish(); //キャラのステート変えるやつ　待機

    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// ゲーム開始時にリセット
    /// </summary>
    /// <returns></returns> 
    public static void GameParamReset()
    {
        gameCurrentTime = 0.0f;
        questionNumOfTimes = 0;
        getDeltaTime = 0.0f;
        gameStart = false;
        gameFinish = false;
        anserTime = 0.0f;
        questionStatus = false;
        switchIdle = false;
        switchQuestion = false;

    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////

    public void ReLoadKMHH()
    {
        GameParamReset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }



    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// デバッグ情報消し
    /// </summary>
    /// <returns></returns> 
    public void DebugTextOnOff()
    {
        if (debugTextSwitch)
        {

            debugGameTimeText.enabled = false;
            KMHH_ScoreManager.debug_LookScoreValText.enabled = false;
            KMHH_CharaAnimationManager.partsInfoText.enabled = false;
        }
        else
        {

            debugGameTimeText.enabled = true;
            KMHH_ScoreManager.debug_LookScoreValText.enabled = true;
            KMHH_CharaAnimationManager.partsInfoText.enabled = true;
        }
        debugTextSwitch = !debugTextSwitch;

    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////



    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////
    /// <summary>
    /// デバッグ スピードアップしない
    /// </summary>
    /// <returns></returns> 
    public void DebugCharaSpeedOnOff()
    {
        debugSpeedUpONOFF = !debugSpeedUpONOFF;

        if (debugSpeedUpONOFF == true)
        {
            debugSpeedUpONOFFText.text = ("SpeedUp On");
        }
        else if(debugSpeedUpONOFF == false)
        {

            debugSpeedUpONOFFText.text = ("SpeedUp Off");
        }

    }
    ////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////


}
