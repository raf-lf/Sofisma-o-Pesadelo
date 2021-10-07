using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCadeiraRodas : MonoBehaviour
{
    public AudioClip[] rodas = new AudioClip[5];
    

    void BarulhoRoda()
    {
        AudioSource audiosource = GetComponent(typeof(AudioSource)) as AudioSource;

        float sorteio1 = Random.Range(-0.1f, 0.1f);
        audiosource.pitch = 1 + sorteio1;

        int sorteio2 = (int)Random.Range(0, 5);
        audiosource.PlayOneShot(rodas[sorteio2], 1);

    }
}
