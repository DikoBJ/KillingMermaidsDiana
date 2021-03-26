using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LukeScoreScript : MonoBehaviour
{
    public static int scoreValueLuke=0;

    public Text Luke;


    void Start()
    {
    
        Luke=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Luke.text ="Luke: "+scoreValueLuke;
    }
}