
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class HudBarras : MonoBehaviour
{
    public Image barraLuz;
    public Image barraMedo;
    public GameObject luzOn;
    public GameObject luzOff;

    void Update()
    {
        float sModLuz = Globals.LANTERN/100;
        Vector2 scaleChangeLuz = new Vector2(barraLuz.transform.localScale.x, sModLuz);
        barraLuz.rectTransform.localScale = scaleChangeLuz;

        var nictofobia = GameObject.FindObjectOfType(typeof(Nictofobia)) as Nictofobia;
        if (nictofobia != null)
        {
            float medo = nictofobia.medo;
            float sModMedo = medo / 100;
            Vector2 scaleChangeMedo = new Vector2(barraMedo.transform.localScale.x, sModMedo);
            barraMedo.rectTransform.localScale = scaleChangeMedo;

            if (nictofobia.luz >0)
            {
                luzOn.SetActive(true);
                luzOff.SetActive(false);
            }

            else
            {
                luzOn.SetActive(false);
                luzOff.SetActive(true);
            }

        }


        //       float pModifier = barra.transform.position.x - (barra.transform.localScale.x)/20000;
        //        Vector3 positionChange = new Vector2 (pModifier, barra.transform.position.y);;
        //       sprite.transform.position = positionChange;       

    }
}
