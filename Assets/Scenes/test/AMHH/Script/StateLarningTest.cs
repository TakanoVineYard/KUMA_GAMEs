using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateLarningTest : MonoBehaviour
{
    // virtual, って付いてるメソッドは、継承したクラス側（派生クラスと言います）で上書き（overrideといいます）できます
    //　上書きすると、OnUpdateを呼び出した際に派生クラスの処理が実行されるようになります
    public virtual void OnUpdate() { }


    public static float second = 0f;

    void Update()
    {
        second = Time.deltaTime;

        if(((int)second % 5) == 0)
        {
            OnUpdate();
        }

    }
}


//　継承したクラス
public class StateInitialize : StateLarningTest
{

    // override
    public override void OnUpdate ()
    {
        Debug.Log("あっぷでーと中");
    }
}

public class GameManage : MonoBehaviour
{
    private StateLarningTest state;

    public void ChangeStateInitialize ()
    {
       // stateをこんな漢字で切り替える
        state = new StateInitialize ();
    }
    private void Update ()
    {
        // Update中の処理は、Stateに任せる
        state.OnUpdate ();
    }
}

