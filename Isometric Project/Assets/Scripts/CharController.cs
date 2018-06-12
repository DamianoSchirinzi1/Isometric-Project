using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    [SerializeField]
    private float speed;

    private float startingSpeed;
    [HideInInspector]
    public Vector2 direction;

	// Use this for initialization
	void Start ()
    {
        startingSpeed = speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        GetInput();
	}

    public void Move()
    {        
        //This method applies force to the player to move it.
        transform.Translate(direction * speed * Time.deltaTime);        
    }

    private void GetInput()
    {
        //Resets direction each time the method is called
        direction = Vector2.zero;
        
        //This method determines which direction the player should move depending on the input recieved
        //Divind the Y transform by 2 translates the vector from cartesian coordinates to isometric.
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up / 2 + Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left + Vector2.up / 2;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down / 2 - Vector2.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right - Vector2.up / 2;
        }       

    }    
}
