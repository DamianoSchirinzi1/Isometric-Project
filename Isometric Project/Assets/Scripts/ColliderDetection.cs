using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{

    CharController CC;
    int layerMask;

    GameObject walls;
    //GameObject[] obstacles;

    private void Start()
    {
        layerMask = ~(LayerMask.GetMask("Obstacle"));
        CC = GetComponent<CharController>();

        walls = GameObject.FindGameObjectWithTag("Walls");
        //obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
    }

    void FixedUpdate()
    {
        RaycastObjects();
    }

    void RaycastObjects()
    {
        //Creating a raycast from the players position which points in the players current direction
        //DrawRay paints a ray which follows the raycast i created.
        Debug.DrawRay(transform.position, CC.direction, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, CC.direction, 1);

        if (hit.collider == null)
        {
            return;
        }

        //Checks if the raycast has detected a wall
        if (hit.collider.gameObject == walls)
        {
            Debug.Log("Raycast : " + hit.collider.gameObject.tag);
            //Checks the distance from the origin of the raycast too the hit game object. If below the number specified it will excute the code below.
            if (hit.distance <= 0.08f)
            {
                //Provides negative force to push the player away from the wall.
                print("Player is nearing an obstacle = " + hit.distance);
                transform.Translate(-CC.direction * 1.25f * Time.deltaTime);
            }
        }

        if (hit.collider.gameObject.tag == "Obstacle")
        {
            Debug.Log("Raycast : " + hit.collider.gameObject.tag);
            //Checks if the player is currently phasing
            if (hit.distance <= 0.08f && CC.phasing != true)
            {
                print("Player is nearing an obstacle = " + hit.distance);
                transform.Translate(-CC.direction * 1.25f * Time.deltaTime);
            }
            //If they are not phasing, the will not be pushed away from the object
            else if (hit.distance <= 0.08f && CC.phasing == true)
            {
                //Add particle and sound effects
            }
        }
    }


}

