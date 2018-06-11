using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour {

    public float floatHeight;
    public float liftForce;
    public float damping;
    public Rigidbody2D rb2D;

    private LayerMask LayerObstacle;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        LayerObstacle = LayerMask.NameToLayer("Obstacle");
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector2.up + Vector2.right, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up + Vector2.right);
        if (hit.collider != null)
        {            
            print("Obstacle Destected");
            ////float distance = Mathf.Abs(hit.point.y - transform.position.y);
            ////float heightError = floatHeight - distance;
            ////float force = liftForce * heightError - rb2D.velocity.y * damping;
            ////rb2D.AddForce(Vector3.up * force);
        }
    }
}
