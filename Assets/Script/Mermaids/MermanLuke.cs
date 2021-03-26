using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MermanLuke : MonoBehaviour
{
    public Transform moveSpot;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private SpriteRenderer mySpriteRenderer;

    private GameObject[] multipleTargets;
    public Transform closestTarget;
    public bool targetContact;

    public GameObject GameController;
    Animator animator;
    bool StartMoving = false;
    public float speed;
    public float destroyTimer;
    private LukeScoreScript LukeScoreScript;
    


    void Start()
        {
        closestTarget = null;
        targetContact = false;

        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        moveSpot.position =new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
        }
    


    void Update()
    {  
        StartMoving = GameController.GetComponent<CountdownController>().GameStart;
        //Movement code
        if(StartMoving)
        {
            animator.SetBool("Start", true);


            if(targetContact==true && closestTarget!=null)
            {
                transform.position=Vector2.MoveTowards(transform.position,closestTarget.position, speed * Time.deltaTime);
            }

            else if (Vector2.Distance(transform.position,moveSpot.position) < 0.2f)
            {
                moveSpot.position =new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
                if(transform.position.x>moveSpot.position.x)
                {
                mySpriteRenderer.flipX=true;
                }
                else
                {
                mySpriteRenderer.flipX=false;
                }
            }
            else 
            {
                transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
            }
            }


    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="target")
        {
            closestTarget = getClosestTarget();
            closestTarget.gameObject.GetComponent<SpriteRenderer>().material.color =new Color(1,0.7f, 0,1);
            targetContact=true;
            Destroy(collision.gameObject, destroyTimer);
            LukeScoreScript.scoreValueLuke+=1;

        }

    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="target" && closestTarget!=null )
        {
            targetContact =false;
            closestTarget.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        }

    }


    public Transform getClosestTarget()
    {
        multipleTargets = GameObject.FindGameObjectsWithTag("target");
        float closestDistance = Mathf.Infinity;
        Transform trans =null;

        foreach(GameObject go in multipleTargets)
        {
            float currentDistance = Vector3.Distance(transform.position, go.transform.position);

            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;  
            }
        }
        return trans;
    }

        void OnDestroy()
    {
        LukeScoreScript.scoreValueLuke+=1;
    }
}
