using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grades : MonoBehaviour
{
    public int andar;

    public void Open()
    {
        Animator anim;
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetInteger("state", 2);
    }

    public void OpenIfOnFloor() { 
        {
            var script = FindObjectOfType(typeof(Elevador_Principal)) as Elevador_Principal;
            if (script.posição == andar)
            {
                Open();
            }
        }
    }

    public void Close()
    {
        Animator anim;
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetInteger("state", -2);
    }
}
