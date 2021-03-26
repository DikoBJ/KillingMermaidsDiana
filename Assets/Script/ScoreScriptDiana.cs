using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptDiana : MonoBehaviour
{
    public static int scoreValueDiana=0;

    public Text Diana;


    void Start()
    {
    
        Diana=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        Diana.text ="Diana: "+scoreValueDiana;
    }
}