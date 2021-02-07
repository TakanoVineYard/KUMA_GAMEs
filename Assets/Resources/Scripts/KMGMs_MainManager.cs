using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KMHH_ScoreResultManager;
using static KMGMs_SoundManager;
using static KMGMs_SoundVolumeManager;

using TMPro; //TextMeshPro用

using UnityEngine.SceneManagement; //シーン切り替え

public class KMGMs_MainManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
        //kmhh_GameTimeSlider = GetComponent<Slider>();

        Debug.Log("MasterVolSave:" + PlayerPrefs.GetFloat("KMHH_MasterVolSave"));

        Debug.Log("BGMVolSave:" + PlayerPrefs.GetFloat("KMHH_BGMVolSave"));

        Debug.Log("SEVolSave:" + PlayerPrefs.GetFloat("KMHH_SEVolSave"));

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoToInfo()
    {
        Invoke("DerayMoveKMGMs_Info", 1.0f);
    }
    public void GoToOption()
    {
        Invoke("DerayMoveKMGMs_Option", 1.0f);
    }

    public void GoToKMHH()
    {
        Invoke("DerayMoveKMHH", 1.0f);
    }
    public void GoToKMGMs_Main()
    {
        Invoke("DerayMoveKMGMs_Main", 1.0f);
    }

    public void DerayMoveKMHH()
    {
            SceneManager.LoadScene("KMHH");
    }

    public void DerayMoveKMGMs_Main()
    {
        SceneManager.LoadScene("KMGMs");
    }
    public void DerayMoveKMGMs_Option()
    {
        KMGMs_SoundVolumeManager.soundVolumeLoad = true;

        SceneManager.LoadScene("KMGMs_Option");
        KMGMs_SoundManager.lifeJudge = false;
    }
    public void DerayMoveKMGMs_Info()
    {
        SceneManager.LoadScene("KMGMs_Info");
        KMGMs_SoundManager.lifeJudge = false;
    }



}
