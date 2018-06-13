using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    [SerializeField]
    private float speed;

    private float startingSpeed = 1f;
    [HideInInspector]
    public Vector2 direction;

    //Phase Variables
    SpriteRenderer spriteRenderer;
    Color phasingColor;
    int fPressed = 0;
    bool phasing;

    // Use this for initialization
    void Start()
    {
        phasing = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        phasingColor = this.gameObject.GetComponent<SpriteRenderer>().color;        
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
        #region Movement
        //Resets direction each time the method is called
        direction = Vector2.zero;

        bool sprinting = false;

        while (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += 10f;
        }                
        
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
        #endregion

        #region GhostPhasing
        //Checks for input and if player is currently phasing
        if (Input.GetKeyDown(KeyCode.F) && phasing == false)
        {
            phasing = true;
            fPressed += 1;
            print("F has been pressed " + fPressed + " times. ");
            //Reduces the sprite renderers alpha value by setting it to the value stored in phasingColor.a
            phasingColor.a -= 0.35f;
            spriteRenderer.GetComponent<SpriteRenderer>().color = phasingColor;         
        }
        else if (Input.GetKeyDown(KeyCode.F) && phasing == true)
        {
            phasing = false;
            //Raises the sprite renderers alpha value
            phasingColor.a += 0.35f;
            spriteRenderer.GetComponent<SpriteRenderer>().color = phasingColor;
        }
        #endregion

    }
}
