using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachDetachCollider : MonoBehaviour
{
    public GameObject parent;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (parent == null)
        {
            parent = this.gameObject;
        }

        otherCollider.transform.parent = parent.transform;

    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (parent == null)
        {
            parent = this.gameObject;
        }

        otherCollider.transform.parent = null;
    }
}