using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Audio;
using UnityEngine.SceneManagement; // コレ重要

using TMPro; //TextMeshPro用
public class KMGMs_GameLevelManager : MonoBehaviour
{

    public static int kmhh_GameLevel = 0;
    public GameObject kmhh_GameLevelObj;
    public static TMP_Dropdown kmhh_GameLevelDropdown;
    public AudioSource seSelectLevel;

    float countDeltaTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        kmhh_GameLevelDropdown = kmhh_GameLevelObj.GetComponent<TMP_Dropdown>();

        kmhh_GameLevelDropdown.value = PlayerPrefs.GetInt("kmhhGameLevel", 0);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "KMGMs"){
            countDeltaTime += Time.deltaTime;
        }
        else
        {
            countDeltaTime = 0.0f;
        }

    }



    public void KMHHOnValueChanged(int value)
    {
        Debug.Log("どろっぷ" + value);
        switch (value)
        {
            case 0:
                KMHHLevelNormal();
                break;
            case 1:
                KMHHLevelEasy();
                break;
            case 2:
                KMHHLevelHard();
                break;
        }
    }

    public void KMHHLevelNormal()
    {

        kmhh_GameLevel = 0;
        PlayerPrefs.SetInt("kmhhGameLevel", 0);
        PlayerPrefs.Save();

    }

    //こっち向いてホイホイのレベル　イージー
    //　スピードアップなし
    //  時間ちょっと短い　50s
    public void KMHHLevelEasy()
    {
        kmhh_GameLevel = 1;
        PlayerPrefs.SetInt("kmhhGameLevel", 1);
        PlayerPrefs.Save();
    }

    //こっち向いてホイホイのレベル　ハード
    //　スピードアップあり
    //  時間おなじ
    public void KMHHLevelHard()
    {
        kmhh_GameLevel = 2;
        PlayerPrefs.SetInt("kmhhGameLevel", 2);
        PlayerPrefs.Save();
    }

    public void playSelectSE()
    {
        if(countDeltaTime > 0.5f){
            seSelectLevel.Play();

        }
    }
}
