using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class General_Game_Rules : MonoBehaviour
{
    /**
    - Base Movement Speed
    - No teleporting
    - 1 Power up at a time
    - Power ups spawn in random positions*
    - Attack distance
    - The more you drown > the faster you get (limited, little buff)
    **/ 
    
    public float MovementSpeed = 200f;
    public float AttackDis = 5f;
    public int Score = 0;
    //public vector2 KSM = new Vector2(0.05f,0.2f); //Kill speed modifier

    //Power ups; speed boost / *double drowner/ steal power up?

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
     // this.MovementSpeed + (this.Score * Time.deltaTime) 

    }
}
