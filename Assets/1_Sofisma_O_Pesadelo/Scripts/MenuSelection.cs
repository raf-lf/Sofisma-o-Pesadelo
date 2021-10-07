using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuSelection : MonoBehaviour
{
    public int cursorPosition = 1;
    public int buttonNumber = 2;
    public Vector2 positionMod;
    public string nextScene;
    
   // public float positionMod = 150;
    public AudioClip[] chime = new AudioClip[3];
    private bool blockInput=false;
    private float startPositionX;
    private float startPositionY;
    private Image image;
    private GameObject fade;
    private Animator fadeAnimator;
    private Animator animator;
    private AudioSource audioSource;
    private GameObject music;
    private AudioSource musicSource;
    private Vector2 cursorChange;
    private float timer=0;
    private bool transition = false;

    private void Start()
    {
        image = GetComponent(typeof(Image)) as Image;
        animator = GetComponent(typeof(Animator)) as Animator;
        audioSource = GetComponent(typeof(AudioSource)) as AudioSource;
        fade = GameObject.Find("Fade");
        fadeAnimator = fade.GetComponent(typeof(Animator)) as Animator;
        music = GameObject.Find("Music");
        musicSource = music.GetComponent(typeof(AudioSource)) as AudioSource;
        startPositionX = image.rectTransform.localPosition.x;
        startPositionY = image.rectTransform.localPosition.y;
    }

    public void ButtonPress()
    {
        animator.SetBool("press", true);
        blockInput = true;

    }
    public void ButtonStop()
    {
        animator.SetBool("press", false);

    }

    public void UpdateCursorPosition(int order)
    {
        switch (order)
        {
            case (1):
                cursorChange = new Vector2(transform.localPosition.x + positionMod.x, transform.localPosition.y + positionMod.y);
                image.rectTransform.localPosition = cursorChange;
                break;
            
            case (2):
                cursorChange = new Vector2(transform.localPosition.x - positionMod.x, transform.localPosition.y - positionMod.y);
                image.rectTransform.localPosition = cursorChange;
                break;

            case (3):
                cursorChange = new Vector2(startPositionX, startPositionY);
                image.rectTransform.localPosition = cursorChange;
                break;

            case (4):
                cursorChange = new Vector2(startPositionX - positionMod.x * (buttonNumber - 1), startPositionY - positionMod.y * (buttonNumber-1));
                image.rectTransform.localPosition = cursorChange;
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && blockInput==false)
        {
            audioSource.PlayOneShot(chime[2], 0.5f);

            if (cursorPosition <= 1)
            {
                cursorPosition = buttonNumber;
                UpdateCursorPosition(4);
            }
            else
            {
                cursorPosition -= 1;
                UpdateCursorPosition(1);
            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && blockInput == false)
        {
            audioSource.PlayOneShot(chime[1], 0.5f);

            if (cursorPosition >= buttonNumber)
            {
                cursorPosition = 1;
                UpdateCursorPosition(3);
            }
            else
            {
                cursorPosition += 1;
                UpdateCursorPosition(2);
            }

        }

        if (Input.GetKeyDown(KeyCode.Return) && blockInput == false)
        {
            audioSource.PlayOneShot(chime[0], 0.5f);

            switch (cursorPosition)
            {
                case (1):
                    ButtonPress();
                    break;

                case (2):
                    ButtonPress();
                    break;
            }

            fadeAnimator.SetInteger("state", 1);
            transition = true;
        }
    }

    private void FixedUpdate()
    {
        if (transition==true)
        {
            if (musicSource != null) musicSource.volume -= 0.1f;
            timer += Time.deltaTime;
            
            if (timer>=1)
            {
                switch (cursorPosition)
                {
                    case (1):
                        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
                        break;

                    case (2):
                        Globals.IDIOMA += 1;
                        if (Globals.IDIOMA > 1) Globals.IDIOMA = 0;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                        break;

                    case (3):
                        Application.Quit();
                        break;
                }

                fadeAnimator.SetInteger("state", 0);
                transition = false;
                blockInput = false;
                timer = 0;
            }
        }
    }

}
