using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour {

    //SET TO POSITIONS USING WAYPOINTS
    public Transform movingTrap;
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;
    public string currentState;
    public float smooth;
    public float resetTime;

    //DIFFERENT SPEED AND DAMAGE VARIABLES
    
    private void Start()
    {
        ChangeTarget();
    }

    private void FixedUpdate()
    {
        movingTrap.position = Vector3.Lerp(movingTrap.position, newPosition, smooth * Time.deltaTime);
    }

    void ChangeTarget()
    {
        if(currentState == "Moving To Position 1")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        else if (currentState == "Moving To Position 2")
        {
            currentState = "Moving To Position 1";
            newPosition = position1.position;
        }
        else if (currentState == "")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Player Detected");
        }
    }
}
