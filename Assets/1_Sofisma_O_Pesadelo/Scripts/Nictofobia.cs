using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Nictofobia : MonoBehaviour
{
    public float medo;
    public int luz;
    public GameObject deathEffect;
    public ParticleSystem insanity;
    public AudioSource song;
    public GameObject insanityBurst;

    void Update()
    {

        if (luz <=0)
        {

            if (Globals.LANTERN <= 0)
            {
                if (medo >= 100)
                {
                    medo = 100;
                }
                else
                {
                    medo += Time.deltaTime * 10;
                }

            }
        }

        else if (luz >0)
        {
            if (medo <= 0)
            {
                medo = 0;
            }
            else
            {
                medo -= Time.deltaTime * 30;
            }
        }

        if (Globals.LANTERN > 0)
        {
            if (medo <= 0)
            {
                medo = 0;
            }
            else
            {
                medo -= Time.deltaTime * 30;
            }

        }
        var emission = insanity.emission;
        var main = insanity.main;
        //var shape = insanity.shape;
        emission.rateOverTime = medo;
        main.startLifetime = medo/66;
        //        emission.rateOverTime = medo * ((medo / 50) * medo / 50);
        //        main.startSize = medo / 10;
        //        shape.radius = 10 - (medo / 20);
       song.volume = ((medo / 100) * (medo / 100));

        if (medo >= 100)
        {
            MadDeath();
        }
    }

    public void MadDeath()
    {
        Destroy(this.gameObject);
        GameObject newObject = Instantiate<GameObject>(deathEffect);
        newObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.y);
        GameObject newObject2 = Instantiate<GameObject>(insanityBurst);
        newObject2.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Área Iluminada"))
        {
            luz += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
       {
           if (collision.CompareTag("Área Iluminada"))
           {
            luz -= 1;
           }
       }


/*           private void OnTriggerStay2D(Collider2D collision)
           {
               if (collision.CompareTag("Luz"))
               {
                   fear -= Time.deltaTime;
                   print("Entrou na luz");
               }
               else if (collision.CompareTag("Sombra"))
               {
                   fear += Time.deltaTime;
                   print("Entrou sombra");
               }
           }
           */
}
