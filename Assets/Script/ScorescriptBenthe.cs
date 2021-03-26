using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorescriptBenthe : MonoBehaviour
{
    public static int scoreValueBenthe=0;

    public Text Benthe;


    void Start()
    {
    
        Benthe=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        Benthe.text ="Benthe: "+scoreValueBenthe;
    }
}