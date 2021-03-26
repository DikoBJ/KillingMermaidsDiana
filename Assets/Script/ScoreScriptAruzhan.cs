using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptAruzhan : MonoBehaviour
{

    public static int scoreValueAruzhan=0;

    public Text Aruzhan;


    void Start()
    {
    
        Aruzhan=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        Aruzhan.text ="Aruzhan: "+scoreValueAruzhan;
    }
}