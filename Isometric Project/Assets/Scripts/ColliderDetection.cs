using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour {

    CharController CC;
    int layerMask;
    //public float floatHeight;
    //public float liftForce;
    //public float damping;
    //public Rigidbody2D rb2D;

    private void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
        layerMask = ~(LayerMask.GetMask("Obstacle"));
        CC = GetComponent<CharController>();
        //layerMask = LayerMask.NameToLayer("Obstacle");
    }
    
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, CC.direction, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, CC.direction, 1);
        if (hit.collider != null)
        {
            Debug.Log("Raycast : " + hit.collider.gameObject.tag);
            if(hit.distance <= 0.05f )
            {
                print("Player is nearing an obstacle = " + hit.distance);
                transform.Translate(-CC.direction * 2f * Time.deltaTime);
            }
            //float distance = Mathf.Abs(hit.point.y - transform.position.y);
            //float heightError = floatHeight - distance;
            //float force = liftForce * heightError - rb2D.velocity.y * damping;
            //rb2D.AddForce(Vector3.up * force);
        }
    }
}
