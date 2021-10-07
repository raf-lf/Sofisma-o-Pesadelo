using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefeDirection : MonoBehaviour
{
    public int direction;
    public GameObject chefe;

    public void OnTriggerEnter2D(Collider2D entering)
    {
        if (entering.CompareTag("Player"))
        {
            var script = chefe.GetComponent(typeof(Chefe)) as Chefe;
            script.direction = direction;
        }
    }
}
