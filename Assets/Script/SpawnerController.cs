using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] DiverPrefabs;
    public float RespawnTime = 10.0f;
    public float MaximumAmountOfDivers = 30;

    public Vector2[] SpawnPoints;
    private float DiversInScene = 0;
    private bool Spawn = false;

    private Vector2 RandomPosition;
    private Vector2 moveSpot;
    public Camera cam;

    void Start()
    {
        // spawns 5 divers at the start and randomizes their positions
        for (int i = 0; i < 5; i++)
        {
            PositionRandomize();
            Instantiate(DiverPrefabs[Random.Range(0, DiverPrefabs.Length - 1)], RandomPosition, Quaternion.identity);
            DiversInScene++;
        }
    }
    void Update()
    {
    }
    
    //this function is called from CountownController to start spawning when the game starts
    public void StartSpawning()
    {
        StartCoroutine(Spawning());
    }

    //spawning divers
    private void SpawnDiver()
    {

        Instantiate(DiverPrefabs[Random.Range(0, DiverPrefabs.Length-1)], SpawnPoints[Random.Range(0, SpawnPoints.Length)], Quaternion.identity);
    }

    //calls function SpawnDiver every RespawnTime
    IEnumerator Spawning()
    {
        while (DiversInScene < MaximumAmountOfDivers)
        {
            yield return new WaitForSeconds(RespawnTime);
            SpawnDiver();
            DiversInScene++;
        }
    }

    //same function as in targetscript
    void PositionRandomize()
    {
        RandomPosition.x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        RandomPosition.y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        Vector2 ViewPos = cam.WorldToViewportPoint(RandomPosition);
        if (ViewPos.y > 0.5f)
        {
            moveSpot = new Vector2(RandomPosition.x, RandomPosition.y);
        }
        else
        {
            PositionRandomize();
        }
    }


}
