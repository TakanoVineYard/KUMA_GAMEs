using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //テキスト使うなら必要？

public class DebugQuestionTime : MonoBehaviour
{

    private GameObject debugQuestionTime;

    public CharacterTest at;

    public Text debugQTText;


    // Start is called before the first frame update
    void Start()
    {

        debugQuestionTime = GameObject.Find("QuestionTime"); //出題中カウント用のオブジェクトをひっぱる

        at = GameObject.Find("ThendBear").GetComponent<CharacterTest>();

        debugQTText = GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        debugQTText.text = "count:" + (Mathf.Floor(at.endTime * 10) / 10).ToString();


    }
}
