using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro用

public class KMGMs_InfoManager : MonoBehaviour
{

    public TextMeshProUGUI kmgmsKumaCoinVal;
    // Start is called before the first frame update
    void Start()
    {
        kmgmsKumaCoinVal.text = ("<bounce>" +(PlayerPrefs.GetInt("KumaCoinValue", 0)).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
