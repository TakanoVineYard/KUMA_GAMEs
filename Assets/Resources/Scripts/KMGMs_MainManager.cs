using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KMHH_ScoreResultManager;

using TMPro; //TextMeshPro用

using UnityEngine.SceneManagement; //シーン切り替え

public class KMGMs_MainManager : MonoBehaviour
{
    public Slider debug_kmhh_GameTimeSlider;
    public TextMeshProUGUI debug_kmhh_GameTimeSliderVal;
    public static int sliderKMHHGameTime;

    // Start is called before the first frame update
    void Start()
    {
        //kmhh_GameTimeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
    }
        public void GoToOption()
    {
        Debug.Log("hogeOption");
        Invoke("DerayMoveKMGMs_Option", 1.0f);
    }

    public void GoToKMHH()
    {
        Debug.Log("hoge");
        Invoke("DerayMoveKMHH", 1.0f);
    }
    public void DerayMoveKMHH()
    {

            SceneManager.LoadScene("KMHH");
    }

    public void DerayMoveKMGMs_Option()
    {

            SceneManager.LoadScene("KMGMs_Option");
    }


    public void GetKMHHGameTimeSliderVal(){
       sliderKMHHGameTime = (int)debug_kmhh_GameTimeSlider.value;
       debug_kmhh_GameTimeSliderVal.text = "GameTime\n" + sliderKMHHGameTime.ToString() + " sec";

    }

}
