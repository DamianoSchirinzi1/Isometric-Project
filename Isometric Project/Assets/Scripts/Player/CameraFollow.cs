using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    //The higher this value is, the quicker it will lock onto the target.
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    private void LateUpdate()
    {
        //desiredPosition is the position i want the camera to be in.
        Vector3 desiredPosition = target.position + offset;
        //smooth position takes desired position and uses lerp to delay the camera from getting into the right position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //For camera scripts, use late update so that the code is run after the player has executed its movements.
        //Adding the offset to the vector value of the transform
        transform.position = target.position + offset;

        transform.LookAt(target);
    }
}
