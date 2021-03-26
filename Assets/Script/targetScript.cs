using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class targetScript : MonoBehaviour
{
    
    public float speed;
    private SpriteRenderer mySpriteRenderer;
    private Vector2 moveSpot;
    private Vector2 RandomPosition;
    private GameObject CameraObj;
    public Camera cam;
    
  
    void Awake()
    {
        CameraObj = GameObject.Find("Main Camera");
        cam = CameraObj.GetComponent<Camera>();
        PositionRandomize();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
 
    void Update () {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position,moveSpot) < 0.2f)
         {
            PositionRandomize();
            if (transform.position.x>moveSpot.x)
            {
            mySpriteRenderer.flipX=true;
            }
            else
            {
            mySpriteRenderer.flipX=false;
            }
        }
       
    }

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
