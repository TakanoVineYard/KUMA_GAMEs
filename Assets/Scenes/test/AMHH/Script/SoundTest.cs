using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public static AudioClip soundCountDown;

    public static AudioClip soundGameStart;
    public static AudioClip soundGameBGM;
    public static AudioClip soundCorrect;
    public static AudioClip soundIncorrect;
    public static AudioClip soundGameCuestion;

    public static AudioSource GameAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        GameAudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
