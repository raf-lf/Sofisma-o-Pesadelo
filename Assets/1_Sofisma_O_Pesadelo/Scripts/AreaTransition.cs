using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    public string nextScene;
    private GameObject fade;
    private Animator fadeAnimator;
    private GameObject music;
    private AudioSource musicSource;
    private float timer = 0;
    private bool transition = false;

    private void Start()
    {
        fade = GameObject.Find("Fade");
        fadeAnimator = fade.GetComponent(typeof(Animator)) as Animator;
        music = GameObject.Find("Music");
        if (musicSource!=null) musicSource = music.GetComponent(typeof(AudioSource)) as AudioSource;
    }

    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")==true)
        {
            Transition();
        }
    }

    public void Transition()
    {
        fadeAnimator.SetInteger("state", 1);
        transition = true;

    }

    void FixedUpdate()
    {
        if (transition == true)
        {
            if (musicSource != null) musicSource.volume -= 0.1f;
            timer += Time.deltaTime;

            if (timer >= 1)
            {
                fadeAnimator.SetInteger("state", 0);
                timer = 0;
                transition = false;
                SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
            }
                
            }
        }
    }
