using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CinematicCall : MonoBehaviour
{
    public int textToCall;

    public void Run()
    {
        //Aqui ele vai pegar o build index da cena como referencia para saber onde guardar o texto na matriz cineSkip. 1º valor na matriz é o build index e o segundo é o dialogo
        if (Globals.cineSkip[SceneManager.GetActiveScene().buildIndex, textToCall] == false)
        {
            GameObject cinematic = GameObject.Find("Cinematics");
            var script = cinematic.GetComponent(typeof(Cinematic)) as Cinematic;
            script.Run(textToCall);

            Globals.cineSkip[SceneManager.GetActiveScene().buildIndex, textToCall] = true;
        }


    }

    public static bool[,] cineSkip = new bool[2, 20];
}
