using System.Runtime.CompilerServices;
using UnityEngine;

public class Elevador_Principal : MonoBehaviour
{
    private bool move;
    private bool directionUp;
    public float speed = 0.5f;
    public int posição = 1;
    public AudioSource elevatorLoop;
    public Animator[] CordaA = new Animator[2];
    public Animator[] CordaB = new Animator[2];
    //    public GameObject efeitoGrade;


    //Função executando movimento do elevador
    public void moveStart(bool order)
    {
        toggleGrate(false);
        move = true;
        if (order == true)
        {
            directionUp = true;
            for (int id = 0; id < CordaA.GetLength(0); id += 1) CordaA[id].SetInteger("state", -1);
            for (int id = 0; id < CordaB.GetLength(0); id += 1) CordaB[id].SetInteger("state",  1);
        }
        else
        {
            directionUp = false;

            for (int id = 0; id < CordaA.GetLength(0); id += 1) CordaA[id].SetInteger("state",  1);
            for (int id = 0; id < CordaB.GetLength(0); id += 1) CordaB[id].SetInteger("state", -1);
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
            if (directionUp == true)
            {
                transform.Translate(0, speed, 0);
            }
            else
            {
                transform.Translate(0, -speed, 0);
            }
        }
        else
        {
            if (elevatorLoop.volume > 0)
            {
                elevatorLoop.volume -= 0.01f;
            }
        }
    }

    //Abre ou fecha as grades para impedir saída do elevador
    private void toggleGrate(bool opening)
    {
    //    GameObject test = Instantiate<GameObject>(efeitoGrade);
    //    test.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.y);

        GameObject[] grades;
        grades = GameObject.FindGameObjectsWithTag("Grade");
        if (grades != null)
        {
            foreach (GameObject grade in grades)
            {
                var script = grade.GetComponent(typeof(Grades)) as Grades;
                    if (opening ==true)
                    {
                    script.OpenIfOnFloor();
                    }
                    else
                    {
                    script.Close();
                    }
 //               Invoke("gradeanimate(1)",1);
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            //Para o elevador ao colidir com as paradas
        if (collision.CompareTag("Elevador"))
        {
            if (directionUp == true) posição -= 1;
            else posição += 1;

            move = false;
            Globals.ORDEM_ELEVADOR = true;
            toggleGrate(true);

            for (int id = 0; id < CordaA.GetLength(0); id += 1) CordaA[id].SetInteger("state", 0);
            for (int id = 0; id < CordaB.GetLength(0); id += 1) CordaB[id].SetInteger("state", 0);
        }
    }


}