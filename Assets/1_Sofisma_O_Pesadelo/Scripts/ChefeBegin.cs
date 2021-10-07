using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class ChefeBegin : MonoBehaviour
{
    public GameObject boss;
    public GameObject bulbOrganizer;
    public float cameraSize = 5;
    public float startCameraSize = 3;
    public GameObject music;
    public GameObject victoryLightObject;
    private Light2D victoryLight;
    private bool victory=false;

    public void Begin()
    {
        Globals.CAMERA_SIZE = cameraSize;

        boss.SetActive(true);
        music.SetActive(true);

        var script = bulbOrganizer.GetComponent(typeof(ChefeSwitchOrganizer)) as ChefeSwitchOrganizer;
        script.Sorteio(1);

        GameObject[] grades;
        grades = GameObject.FindGameObjectsWithTag("Grade");
        if (grades != null)
        {
            foreach (GameObject grade in grades)
            {
                var scriptGrade = grade.GetComponent(typeof(Grades)) as Grades;
                scriptGrade.Close();
            }
        }
    }
    public void End()
    {
        victoryLightObject.SetActive(true);
        victoryLight = victoryLightObject.GetComponent(typeof(Light2D)) as Light2D;
        victory = true;

        Globals.CAMERA_SIZE = startCameraSize;

        //        boss.SetActive(true);
        music.SetActive(false);

        var script = bulbOrganizer.GetComponent(typeof(ChefeSwitchOrganizer)) as ChefeSwitchOrganizer;
 //       script.AllOff();

        GameObject[] grades;
        grades = GameObject.FindGameObjectsWithTag("Grade");
        if (grades != null)
        {
            foreach (GameObject grade in grades)
            {
                var scriptGrade = grade.GetComponent(typeof(Grades)) as Grades;
                scriptGrade.Open();
            }
        }

    }
    private void FixedUpdate()
    {
        if (victory == true)
        { 
            if (victoryLight.intensity < 0.5) victoryLight.intensity += 0.01f;
            if (victoryLight.intensity > 0.5) victoryLight.intensity = 0.5f;
        }
    }
}
