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


    public static void soundCollect()
    {
        kmhh_AudioSources[1].Play();　//
    }

}
