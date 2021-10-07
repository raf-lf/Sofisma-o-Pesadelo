using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAjust : MonoBehaviour
{
    public Camera playerCamera;

    void Update()
    {
        if(playerCamera.orthographicSize > Globals.CAMERA_SIZE)
        {
            playerCamera.orthographicSize -= 0.03f;
            if (playerCamera.orthographicSize < Globals.CAMERA_SIZE)
            {
                playerCamera.orthographicSize = Globals.CAMERA_SIZE;
            }
        }
        else if (playerCamera.orthographicSize < Globals.CAMERA_SIZE)
        {
            playerCamera.orthographicSize += 0.03f;
            if (playerCamera.orthographicSize > Globals.CAMERA_SIZE)
            {
                playerCamera.orthographicSize = Globals.CAMERA_SIZE;
            }
        }
    }


}
