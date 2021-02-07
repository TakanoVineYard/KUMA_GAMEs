using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMGMs_ExternalLinkManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AccessToLINEStore()
    {
        Application.OpenURL("https://store.line.me/stickershop/author/54372/");
    }
}
