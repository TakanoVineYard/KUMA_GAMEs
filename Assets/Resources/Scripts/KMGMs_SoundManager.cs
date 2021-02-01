using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン

public class KMGMs_SoundManager : MonoBehaviour
{
    public GameObject kmgms_SoundManager;

    bool GameOnSwitch = true;
    bool KMHH_ResultOnSwitch =false;
    bool KMHH_OnSwitch =false;

    public static bool lifeJudge = true;

    public AudioSource[] kmgms_AudioSources;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if((SceneManager.GetActiveScene().name == "KMGMs")&&(GameOnSwitch==true)&&(KMHH_ResultOnSwitch == false))
        {

            if (lifeJudge == false)
            {
                lifeJudge = true;
                Destroy(gameObject);
            }
            else{

            lifeJudge = false; //次回死ぬ

            KMHH_OnSwitch = true;

            kmgms_AudioSources = gameObject.GetComponents<AudioSource>();

            Invoke("KMGMsStartBGMPlay",0.5f);

            GameOnSwitch=false;

            DontDestroyOnLoad(this);


            }
        }


        if ((SceneManager.GetActiveScene().name == "KMHH")&&(KMHH_ResultOnSwitch == false)&&(KMHH_OnSwitch == true)){

            KMHH_OnSwitch = false;
            KMHH_ResultOnSwitch = true;
            
            kmgms_AudioSources[2].Stop();　//本ゲームの愉快なBGM流す
            kmgms_AudioSources[0].Play();　//本ゲームの愉快なBGM流す

        }


        if ((SceneManager.GetActiveScene().name == "KMHH_Result")&&(KMHH_ResultOnSwitch == true)){
            KMHH_ResultOnSwitch = false;
            GameOnSwitch = true;
            KMHH_OnSwitch = true;
            
            Invoke("DelayOnKMHHResultSound",0.5f);

        }


    }


    public void DelayOnKMHHResultSound(){
        
            kmgms_AudioSources[0].Stop();　//本ゲームの愉快なBGM流す
            
            kmgms_AudioSources[1].Play();　//本ゲームの愉快なBGM流す
    }

    public void DeleteSoundManager(){
        
            Destroy(gameObject);
    } 

    public void ResultBGMOn(){
    
            kmgms_AudioSources[0].Stop();  
            kmgms_AudioSources[1].Play();
    }


    public void ContinueKMHHBGMOn()
    {
        KMHH_ResultOnSwitch = false;
        GameOnSwitch = false ;
    }

    public void KMGMsStartBGMPlay()
    {
        kmgms_AudioSources[2].Play(); //本ゲームの愉快なBGM流す
        kmgms_AudioSources[0].Stop(); //本ゲームの愉快なBGM流す

    }
}

/*
 
public class KMGMs_SoundManager : SingletonMonoBehaviour<KMGMs_SoundManager>
{
    [SerializeField, Range(0, 1), Tooltip("マスタ音量")]
    float volume = 1;
    [SerializeField, Range(0, 1), Tooltip("BGMの音量")]
    float bgmVolume = 1;
    [SerializeField, Range(0, 1), Tooltip("SEの音量")]
    float seVolume = 1;
 
    AudioClip[] bgm;
    AudioClip[] se;
 
    Dictionary<string, int> bgmIndex = new Dictionary<string, int>();
    Dictionary<string, int> seIndex = new Dictionary<string, int>();
 
    AudioSource bgmAudioSource;
    AudioSource seAudioSource;
 
    public float Volume
    {
        set
        {
            volume = Mathf.Clamp01(value);
            bgmAudioSource.volume = bgmVolume * volume;
            seAudioSource.volume = seVolume * volume;
        }
        get
        {
            return volume;
        }
    }
 
    public float BgmVolume
    {
        set
        {
            bgmVolume = Mathf.Clamp01(value);
            bgmAudioSource.volume = bgmVolume * volume;
        }
        get
        {
            return bgmVolume;
        }
    }
 
    public float SeVolume
    {
        set
        {
            seVolume = Mathf.Clamp01(value);
            seAudioSource.volume = seVolume * volume;
        }
        get
        {
            return seVolume;
        }
    }
 
    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
 
        DontDestroyOnLoad(gameObject);
 
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        seAudioSource = gameObject.AddComponent<AudioSource>();
 
        bgm = Resources.LoadAll<AudioClip>("Audio/BGM");
        se = Resources.LoadAll<AudioClip>("Audio/SE");
 
        for(int i = 0; i < bgm.Length; i++)
        {
            bgmIndex.Add(bgm[i].name, i);
        }
 
        for (int i = 0; i < se.Length; i++)
        {
            seIndex.Add(se[i].name, i);
        }
    }
 
    public int GetBgmIndex(string name)
    {
        if (bgmIndex.ContainsKey(name))
        {
            return bgmIndex[name];
        }
        else
        {
            Debug.LogError("指定された名前のBGMファイルが存在しません。");
            return 0;
        }
    }
 
    public int GetSeIndex(string name)
    {
        if (seIndex.ContainsKey(name))
        {
            return seIndex[name];
        }
        else
        {
            Debug.LogError("指定された名前のSEファイルが存在しません。");
            return 0;
        }
    }
 
    //BGM再生
    public void PlayBgm(int index)
    {
        index = Mathf.Clamp(index, 0, bgm.Length);
 
        bgmAudioSource.clip = bgm[index];
        bgmAudioSource.loop = true;
        bgmAudioSource.volume = BgmVolume * Volume;
        bgmAudioSource.Play();
    }
 
    public void PlayBgmByName(string name)
    {
        PlayBgm(GetBgmIndex(name));
    }
 
    public void StopBgm()
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = null;
    }
 
    //SE再生
    public void PlaySe(int index)
    {
        index = Mathf.Clamp(index, 0, se.Length);
 
        seAudioSource.PlayOneShot(se[index], SeVolume * Volume);
    }
 
    public void PlaySeByName(string name)
    {
        PlaySe(GetSeIndex(name));
    }
 
    public void StopSe()
    {
        seAudioSource.Stop();
        seAudioSource.clip = null;
    }
 
}

*/