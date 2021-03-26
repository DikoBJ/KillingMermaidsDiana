using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public int Time = 120; //in seconds
    public TMP_Text TimerText;
    public TMP_Text EndText; //CountdownText object can be used instead of creating new TMP
    private int initialTime;
    private ScoreScriptDiana ScoreScriptDiana;
    private LukeScoreScript LukeScoreScript;
    private ScoreScriptAruzhan ScoreScriptAruzhan;
    private ScorescriptBenthe ScorescriptBenthe;


    void Start()
    {
        initialTime = Time;
    }

    //function called after countdown
    public void StartTimer()
    {
        StartCoroutine(TimerStart());
    }
    private void CalculateScore()
    {
        if(LukeScoreScript.scoreValueLuke > ScorescriptBenthe.scoreValueBenthe && LukeScoreScript.scoreValueLuke > ScoreScriptAruzhan.scoreValueAruzhan && LukeScoreScript.scoreValueLuke>ScoreScriptDiana.scoreValueDiana )
        {
            EndText.text = "FINISH! Winner is: Luke!!!";
        }
        else if(ScorescriptBenthe.scoreValueBenthe>LukeScoreScript.scoreValueLuke && ScorescriptBenthe.scoreValueBenthe>ScoreScriptAruzhan.scoreValueAruzhan && ScorescriptBenthe.scoreValueBenthe>ScoreScriptDiana.scoreValueDiana )
        {
            EndText.text = "FINISH! Winner is: Benthe!!!";
        }
          else if(ScoreScriptDiana.scoreValueDiana>LukeScoreScript.scoreValueLuke && ScoreScriptDiana.scoreValueDiana>ScoreScriptAruzhan.scoreValueAruzhan && ScoreScriptDiana.scoreValueDiana>LukeScoreScript.scoreValueLuke )
        {
            EndText.text = "FINISH! Winner is: Diana!!!";
        }
          else if(ScoreScriptAruzhan.scoreValueAruzhan>LukeScoreScript.scoreValueLuke && ScoreScriptAruzhan.scoreValueAruzhan> ScorescriptBenthe.scoreValueBenthe && ScoreScriptAruzhan.scoreValueAruzhan>ScoreScriptDiana.scoreValueDiana )
        {
            EndText.text = "FINISH! Winner is: Aruzhan!!!";
        }
        else
        {
            EndText.text = "FINISH! There is no winner!!!";
        }

    }
     public void QuitGame()
 {
     #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
 }

    IEnumerator TimerStart()
    {
        //it will count for every second and substract it. when it is 0 the countdown will stop and show "start!".
        while(Time > 0)
        {
            TimerText.text = "Timer: " + Time.ToString() + "/" + initialTime.ToString() + " sec";

            yield return new WaitForSeconds(1f);

            Time--;
        if (Time==0)
        {

        //"Finish" text shown
        EndText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(false);
        CalculateScore();

        yield return new WaitForSeconds(10f);

        
        EndText.gameObject.SetActive(false);
        QuitGame();
        }
        }

        //End screen
    }
}
