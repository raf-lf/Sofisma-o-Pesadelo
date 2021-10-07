using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Elevador : MonoBehaviour
{
    public Vector2 direction;
    public float interval;
    public int stops;
    private int stopsCount;
    private bool stop;
    private float targetTime;

    public Animator cordaA;
    public Animator cordaB;

    void FixedUpdate()
    {
        if (stop == false)
        {
            transform.Translate(direction);

            if (direction.y > 0)
            {
                cordaA.SetInteger("state", -1);
                cordaB.SetInteger("state", 1);
            }
            else
            {
                cordaA.SetInteger("state", 1);
                cordaB.SetInteger("state", -1);
            }
        }
        else
        {
            if (Time.time >= targetTime)
            {
                if (stopsCount >= stops)
                {
                    stopsCount = 0;
                    direction *= -1;

                }
                stop = false;
            }
        }
    }

//    void interval();

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Elevador"))
        {
            stop = true;
            stopsCount += 1;
            targetTime = Time.time + interval;
                cordaA.SetInteger("state", 0);
                cordaB.SetInteger("state", 0);
        }
    }
}
