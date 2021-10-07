using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idioma_Troca : MonoBehaviour
{
    public GameObject[] alternativa = new GameObject[2];

    void Awake()
    {
        for (int id = 0; id < alternativa.Length; id++)
        {
            alternativa[id].SetActive(false);
        }

        alternativa[Globals.IDIOMA].SetActive(true);

    }
}
