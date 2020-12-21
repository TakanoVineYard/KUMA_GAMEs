using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替え
public class MainTitleTest : MonoBehaviour
{


    




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //SceneManager.LoadScene("MainScene");
    public void TapStartButton()
    {
        Invoke("DerayGameLoadRun", 1);

    }

    public void DerayGameLoadRun()
    {

        SceneManager.LoadScene("Test_ButtonTap");
    }
}


