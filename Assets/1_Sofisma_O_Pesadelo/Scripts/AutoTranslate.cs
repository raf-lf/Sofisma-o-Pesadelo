using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTranslate : MonoBehaviour
{
    public Vector2 speed;
    public float xVariation;
    public float yVariation;
    private float xFinalSpeed;
    private float yFinalSpeed;
    private Vector2 modSpeed;

    private void Awake()
    {
        xFinalSpeed = Random.Range(speed.x - xVariation, speed.x + xVariation);
        yFinalSpeed = Random.Range(speed.y - yVariation, speed.y + yVariation);

        modSpeed = new Vector2(xFinalSpeed, yFinalSpeed);
    }

    private void FixedUpdate()
    {
        transform.Translate(modSpeed);
    }
}
