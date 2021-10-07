using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraSize : MonoBehaviour
{
    public float newSize=3;

    public void Run()
    {
        Globals.CAMERA_SIZE = newSize;
    }

}
