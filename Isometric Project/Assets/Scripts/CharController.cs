using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    [SerializeField]
    private float speed;

    private float startingSpeed;
    private Vector2 direction;

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
        transform.Translate(direction * speed * Time.deltaTime);
        
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up + Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left + Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down - Vector2.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right - Vector2.up;
        }       

    }
}
