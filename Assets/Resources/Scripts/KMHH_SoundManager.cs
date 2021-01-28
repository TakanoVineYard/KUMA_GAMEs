using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMHH_SoundManager : MonoBehaviour
{


    public static AudioSource[] kmhh_AudioSources;


    // Start is called before the first frame update
    void Start()
    {

        kmhh_AudioSources = gameObject.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void soundCollectExcellent()
    {
        kmhh_AudioSources[4].Play();　//
    }

    public static void soundCollectGreat()
    {
        kmhh_AudioSources[5].Play();　//
    }

    public static void soundCollectGood()
    {
        kmhh_AudioSources[6].Play();　//
    }

    public static void soundCollectNotGoodBad()
    {
        kmhh_AudioSources[7].Play();　//
    }


    public static void soundCollectPoor()
    {
        kmhh_AudioSources[7].Play();　//
    }
    public static void soundGameFinish()
    {
        kmhh_AudioSources[10].Play();　//
    }


}
