using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{

    CharController CC;
    int layerMask;

    //public Vector3 offset;


    private void Start()
    {
        layerMask = ~(LayerMask.GetMask("Obstacle"));
        CC = GetComponent<CharController>();
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, CC.direction, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, CC.direction, 1);
        if (hit.collider != null)
        {
            Debug.Log("Raycast : " + hit.collider.gameObject.tag);
            if (hit.distance <= 0.08f)
            {
                print("Player is nearing an obstacle = " + hit.distance);
                transform.Translate(-CC.direction * 1f * Time.deltaTime);
            }
        }
    }


}

