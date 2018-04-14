using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 2.5f;
    public Vector3 offset;
    public Vector3 smoothedPosition;

    public float xDifference;
    public float yDifference;
    public float movementThreshold = 3f;
    
    private void LateUpdate()
    {
        xDifference = target.position.x - transform.position.x;
        yDifference = target.position.y - transform.position.y;
        if (Mathf.Abs(xDifference) > 3 || Mathf.Abs(yDifference) > 3)
        {
            Vector3 desiredPosition = target.position + offset;
            smoothedPosition = Vector3.MoveTowards(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        
    }
}
