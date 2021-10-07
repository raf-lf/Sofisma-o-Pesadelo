using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static float CAMERA_SIZE = 3;
    public static int MAGAZINE = 0;
    public static float LANTERN = 0;
    public static bool ORDEM_ELEVADOR = true;
    public static GameObject player;
    public static int IDIOMA = 1;

    public static bool sala1Pega = false;
    public static bool sala2Pega = false;
    public static bool sala3Pega = false;
    public static bool sala4Pega = false;
    public static bool sala5Pega = false;
    //matriz que checa se as cinematicas dvem ser puladas. 1º valor é buildIndex da cena e o 2º é o ID do texto
    public static bool[,] cineSkip = new bool [10,20];

    public void reset()
    {
        CAMERA_SIZE = 3;
        MAGAZINE = 0;
        LANTERN = 0;
        ORDEM_ELEVADOR = true;
        sala1Pega = false;
        sala2Pega = false;
        sala3Pega = false;
        sala4Pega = false;
        sala5Pega = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
