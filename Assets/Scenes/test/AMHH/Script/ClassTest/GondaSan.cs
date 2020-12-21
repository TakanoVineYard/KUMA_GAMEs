using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GondaSan : Ningen
{
    // Start is called before the first frame update


    Ikimono timePastIkimono = new Ikimono();
    Ningen gondaName = new Ningen();

    int cullentTime = 0;
    int cullentTimePast = 0;
    void Start()
    {

        gondaName.age = 31;
        gondaName.name = "Gonda";

    }

    // Update is called once per frame
    void Update()
    {
        cullentTime = (timePastInt - cullentTimePast);


       if((cullentTime) >= ageSpan){
           AddCullentTimePast();
       }

           Debug.Log(cullentTimePast+"_"+(cullentTime));
        Debug.Log((gondaName.name)+"_"+(gondaName.age)+"_"+timePastInt);
    }

    void AddCullentTimePast(){

           cullentTime = 0;
           cullentTimePast = timePastInt;
           
           gondaName.age += 1;
           Debug.Log(cullentTimePast);
    }

}
