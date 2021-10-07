using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting;
using UnityEditor;
using UnityEngine;


public class Elevador_Uso : MonoBehaviour
{
    //Isso ta fazendo alguma coisa??
    public GameObject elevador;

        public void moveUp()
    {
        if (Globals.ORDEM_ELEVADOR == true)
        {
            Globals.ORDEM_ELEVADOR = false;
            var script = GameObject.FindObjectOfType(typeof(Elevador_Principal)) as Elevador_Principal;
            script.moveStart(true);
            /*       if (custo <= 0)
                   {
                   }
            */
        }
    }

    public void moveDown()

    {
        if (Globals.ORDEM_ELEVADOR == true)
        {
            Globals.ORDEM_ELEVADOR = false;
            var script = GameObject.FindObjectOfType(typeof(Elevador_Principal)) as Elevador_Principal;
            script.moveStart(false);
            /*       if (custo <= 0)
                   {
                   }
            */
        }
    }
}

   