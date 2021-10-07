using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    public Animator animator;
    public GameObject hud;
    private GameObject currentText;
    private bool canSkip = false;

    public AudioClip[] whisper;


    public void CinematicOn()
    {
        animator.SetBool("on", true);
        AudioSource audiosource = GetComponent(typeof(AudioSource)) as AudioSource;
        audiosource.volume = 1;
        if (hud!=null) hud.SetActive(false);
        ShowText();
    }
    public void CinematicOff()
    {
        animator.SetBool("on", false);
        canSkip = false;
        AudioSource audiosource = GetComponent(typeof(AudioSource)) as AudioSource;
        audiosource.volume=0;
        if (hud != null) hud.SetActive(true);
        HideText();
    }

    public void ShowText()
    {
        Animator anim;
        anim = currentText.GetComponent<Animator>();
        anim.SetBool("on", true);
        canSkip = true;
    }

    public void HideText()
    {
        Animator anim;
        anim = currentText.GetComponent<Animator>();
        anim.SetBool("on", false);
        canSkip = false;
    }


    public void Run(int stringId)
    {
        currentText = GameObject.Find("Text" + stringId);

        int sorteio = (int)Random.Range(0, 5);
        AudioSource audiosource = GetComponent(typeof(AudioSource)) as AudioSource;
        audiosource.PlayOneShot(whisper[sorteio], 1);

        CinematicOn();
        if (Globals.player != null)
        {
            var script = Globals.player.GetComponent(typeof(PauseUnpausePlayer)) as PauseUnpausePlayer;
            script.PauseUnpause(true);
        }
    }

    void FixedUpdate()
    {
        if (canSkip == true)
        {
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Escape))
            {
                CinematicOff();
                if (Globals.player != null)
                {
                    var script = Globals.player.GetComponent(typeof(PauseUnpausePlayer)) as PauseUnpausePlayer;
                    if (script != null) script.PauseUnpause(true);
                }
            }
        }
    }
}
