using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cine_Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        for (int cenaId = 0; cenaId < Globals.cineSkip.GetLength(0); cenaId += 1)
        {
            for (int cineId = 0; cineId < Globals.cineSkip.GetLength(1); cineId += 1)
            {
                Globals.cineSkip[cenaId, cineId] = false;
                print("Cinemática de ID " + cineId + " da Cena de ID " + cenaId + " resetada.");
            }
        }
    }
}
