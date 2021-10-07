using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachDetach : MonoBehaviour
{
    public GameObject child;
    public GameObject parent;
    public bool detach;

    void Run()
    {
        if (child = null)
        {
            child = this.gameObject;
        }

        if (parent = null)
        {
            parent = this.gameObject;
        }

        if (detach == true)
        {
                child.transform.parent = null;
        }
        else
        {
            child.transform.parent = parent.transform;
        }

    }
}

