using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

    //Waypoint variables
    public Transform[] patrolPoints;
    private int currentPatrolIndex;
    public int specificPatrolIndex;
    Transform currentPatrolPoint;
    
    public float speed;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        currentPatrolIndex = Random.Range(0, patrolPoints.Length);
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
              
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        //Moves the AI up
        transform.Translate(patrolPointDir * Time.deltaTime * speed);
        
        //Check if AI has reached its waypoint
        if(Vector2.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {
            //Reached patrol point            
            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                //If the index is more than the patrol points length
                //Check to see if their are any more patrol points, if not, go back to the beginning
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }

        // Turn towards current patrol point, find the direction the patrol point is in
        
        //uses the direction of the patrol point to calculate an angle
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg;
        print(angle);
        if(angle > -100f)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }        
    }
}
