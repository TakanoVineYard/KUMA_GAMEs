using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生き物の情報を管理するクラス
/// </summary>
public class Ikimono : MonoBehaviour
{

    public int lifeVal = 1; //命の数
    public float Jumyo = 1.0f;//寿命の長さ
    public int ageSpan = 5; //歳を取る周期　(365日)

        /// <summary>
        //他のクラスで変数の値をそのまま使いたい場合、 public static にする必要がある
        /// <summary>
    public static float timePast = 0; //時間の経過
    public static int  timePastInt = 0; 
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    timePast += Time.deltaTime;

    timePastInt = (int)timePast;
    
    Debug.Log("timePast="+ timePast);

    }


    

}
