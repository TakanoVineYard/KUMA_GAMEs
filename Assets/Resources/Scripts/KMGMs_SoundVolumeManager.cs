using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using static KMGMs_SoundManager;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class KMGMs_SoundVolumeManager : MonoBehaviour
{

    //spublic GameObject slider_SE_Obj;
    //public GameObject slider_BGM_Obj;
    //public GameObject slider_Master_Obj;

    public Slider Slider_SE;
    public  Slider Slider_BGM;
    public Slider Slider_Master;

    public static bool soundVolumeLoad = true;


    public AudioMixer kmgms_audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        soundVolumeLoad = true;
        //   slider_SE_Obj = GameObject.Find("Slider_SE");
        //   slider_BGM_Obj = GameObject.Find("Slider_BGM");
        //   slider_Master_Obj = GameObject.Find("Slider_Master");

        //   Slider_SE = slider_SE_Obj.GetComponent<Slider>();
        //   Slider_BGM = slider_BGM_Obj.GetComponent<Slider>();
        //   Slider_Master = slider_Master_Obj.GetComponent<Slider>();


        //オーディオミキサーの値入れ　-80から0

        kmgms_audioMixer.SetFloat("MasterVolume", (((PlayerPrefs.GetFloat("KMHH_MasterVolSave", 0.0f)) * 0.5f))); //, 0.0f)- 100.0f)* 0.8f));
        kmgms_audioMixer.SetFloat("BGMVolume", (((PlayerPrefs.GetFloat("KMHH_BGMVolSave", 0.0f)) * 0.5f))); //, 0.0f) - 100.0f) * 0.8f));
        kmgms_audioMixer.SetFloat("SEVolume", (((PlayerPrefs.GetFloat("KMHH_SEVolSave", 0.0f)) * 0.5f))); //, 0.0f) - 100.0f) * 0.8f));


        Slider_Master.value = (PlayerPrefs.GetFloat("KMHH_MasterVolSave", 0.0f));
        Slider_BGM.value = (PlayerPrefs.GetFloat("KMHH_BGMVolSave", 0.0f));
        Slider_SE.value = (PlayerPrefs.GetFloat("KMHH_SEVolSave", 0.0f));
    }

    // Update is called once per frame
    void Update()
    {

        //オプションのシーンが読まれてて、
        if (SceneManager.GetActiveScene().name == "KMGMs_Option")
        {
            /*            Debug.Log("otoLoad");
                        Debug.Log("SaveMaster:" + PlayerPrefs.GetFloat("KMHH_MasterVolSave"));
                        Debug.Log("SaveBGM:" + PlayerPrefs.GetFloat("KMHH_BGMVolSave"));
                        Debug.Log("SaveSE:" + PlayerPrefs.GetFloat("KMHH_SEVolSave"));
            */

            if (soundVolumeLoad)
            {
                kmgms_audioMixer.SetFloat("MasterVolume", (((PlayerPrefs.GetFloat("KMHH_MasterVolSave", 0.0f)) * 0.5f))); //, 0.0f)- 100.0f)* 0.8f));
                kmgms_audioMixer.SetFloat("BGMVolume", (((PlayerPrefs.GetFloat("KMHH_BGMVolSave", 0.0f)) * 0.5f))); //, 0.0f) - 100.0f) * 0.8f));
                kmgms_audioMixer.SetFloat("SEVolume", (((PlayerPrefs.GetFloat("KMHH_SEVolSave", 0.0f)) * 0.5f))); //, 0.0f) - 100.0f) * 0.8f));


                Slider_Master.value = (PlayerPrefs.GetFloat("KMHH_MasterVolSave", 0.0f));
                Slider_BGM.value = (PlayerPrefs.GetFloat("KMHH_BGMVolSave", 0.0f));
                Slider_SE.value = (PlayerPrefs.GetFloat("KMHH_SEVolSave", 0.0f));
            
            soundVolumeLoad = false;
            }

            //オーディオミキサーの値入れ　-80から0

        }




    }

    public void SetMaster(float volume)
    {
        if (volume <= -70.0f)
        {
            kmgms_audioMixer.SetFloat("MasterVolume", -80.0f);// - 100.0f) * 0.8f);
        }
        else
        {
            kmgms_audioMixer.SetFloat("MasterVolume", (volume * 0.5f));// - 100.0f) * 0.8f);
        }


        Debug.Log("Master" + volume);

        PlayerPrefs.SetFloat("KMHH_MasterVolSave", volume);
        PlayerPrefs.Save();
        
        Debug.Log("MasterSave:" + PlayerPrefs.GetFloat("KMHH_MasterVolSave"));
    }
    public void SetBGM(float volume)
    {

        if (volume <= -70.0f)
        {
            kmgms_audioMixer.SetFloat("BGMVolume", -80.0f);// - 100.0f) * 0.8f);

        }
        else
        {
            kmgms_audioMixer.SetFloat("BGMVolume", (volume * 0.5f));// - 100.0f) * 0.8f);

        }
        Debug.Log("BGM" + volume);
        
        PlayerPrefs.SetFloat("KMHH_BGMVolSave", volume);
        PlayerPrefs.Save();

        Debug.Log("BGMSave:" + PlayerPrefs.GetFloat("KMHH_BGMVolSave"));

    }
    public void SetSE(float volume)
    {
        if (volume <= -70.0f)
        {
            kmgms_audioMixer.SetFloat("SEVolume", -80.0f);// - 100.0f) * 0.8f);

        }
        else
        {
            kmgms_audioMixer.SetFloat("SEVolume", (volume * 0.5f));// - 100.0f) * 0.8f);

        }
        Debug.Log("SE" + volume);
        
        PlayerPrefs.SetFloat("KMHH_SEVolSave", volume);
        PlayerPrefs.Save();
        Debug.Log("SESave:" + PlayerPrefs.GetFloat("KMHH_SEVolSave"));
    }
}