using System.Runtime.CompilerServices;
using UnityEngine;

public class Elevador_Cinematico : MonoBehaviour
{
    private bool move;
    public float speed = 0.5f;
    public AudioSource elevatorLoop;
    public Animator[] CordaA = new Animator[2];
    public Animator[] CordaB = new Animator[2];

    //Função executando movimento do elevador
    public void Start()
    {
        move = true;
        if (speed > 0)
        {
            for (int id = 0; id < CordaA.GetLength(0); id += 1) CordaA[id].SetInteger("state", 1);
            for (int id = 0; id < CordaB.GetLength(0); id += 1) CordaB[id].SetInteger("state", -1);
        }
        else
        {
            for (int id = 0; id < CordaA.GetLength(0); id += 1) CordaA[id].SetInteger("state", -1);
            for (int id = 0; id < CordaB.GetLength(0); id += 1) CordaB[id].SetInteger("state", 1);
        }
    }

    //Movimento do Elevador
    void FixedUpdate()
    {
        if (move == true)
        {
            if (elevatorLoop.volume<1)
            {
                elevatorLoop.volume += 0.01f;
            }
                transform.Translate(0, speed, 0);
        }
        else
        {
            if (elevatorLoop.volume > 0)
            {
                elevatorLoop.volume -= 0.01f;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
            //Para o elevador ao colidir com as paradas
        if (collision.CompareTag("Elevador"))
        {
            move = false;
            for (int id = 0; id < CordaA.GetLength(0); id += 1) CordaA[id].SetInteger("state", 0);
            for (int id = 0; id < CordaB.GetLength(0); id += 1) CordaB[id].SetInteger("state", 0);
        }
    }


}