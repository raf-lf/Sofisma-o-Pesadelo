using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    public GameObject target;
    public float delay;

    public void run()
    {
        if (target != null)
        {
            Destroy(target, delay);
        }
        else
        {
            //If an object is not assigned, destroy this
            Destroy(this.gameObject, delay);
        }
    }
}
