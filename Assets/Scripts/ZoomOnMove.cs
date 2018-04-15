using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnMove : MonoBehaviour
{
    public Camera mainCamera;
    public NewPlayerController player;
    public float cameraMaxSize = 20f;
    public float cameraStartSize = 15f;
    public float cameraAdjustmentSpeed = 0.5f;
    public CameraFollow cameraFollow;
    // Use this for initialization
    private void Start()
    {
        player = GetComponent<NewPlayerController>();
        mainCamera.orthographicSize = cameraStartSize;
        cameraFollow = mainCamera.GetComponent<CameraFollow>();
    }
    // Update is called once per frame
    void Update ()
    {
        if (cameraFollow == null)
        {
            return;
        }

        var xDiff = Mathf.Abs(cameraFollow.xDifference);
        var yDiff = Mathf.Abs(cameraFollow.yDifference);
		if (Mathf.Abs(player.move.x) > 0 && xDiff > 3 || yDiff > 3)
        {
            if (mainCamera.orthographicSize < cameraMaxSize)
            {
                mainCamera.orthographicSize += cameraAdjustmentSpeed;
            } 
        }
        else
        {
            if (mainCamera.orthographicSize > cameraStartSize)
            {
                if (Mathf.Abs(player.move.x) == 0)
                {
                    mainCamera.orthographicSize -= cameraAdjustmentSpeed;
                }
            }
            
        }
	}
}
