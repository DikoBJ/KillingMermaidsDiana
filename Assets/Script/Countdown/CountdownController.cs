using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public int CountdownTime = 3; //in seconds
    public TMP_Text CountdownText;
    public GameObject GameController;
    public GameObject Spawner;
    public bool GameStart = false;
   
    public void StartCoundown()
    {
        StartCoroutine(CountdownStart());
    }
   

    IEnumerator CountdownStart()
    {
        //it will count for every second and substract it. when it is 0 the countdown will stop and show "start!".
        while(CountdownTime > 0)
        {
            CountdownText.text = CountdownTime.ToString();

            yield return new WaitForSeconds(1f);

            CountdownTime--;
        }

        CountdownText.text = "START!";

        //Begin game and timer
        GameStart = true;
        GameController.GetComponent<TimerController>().StartTimer(); //starts timer
        Spawner.GetComponent<SpawnerController>().StartSpawning(); // starts spawning divers



        yield return new WaitForSeconds(1f);

        //countdown text object disabled
        CountdownText.gameObject.SetActive(false);
    }
}
