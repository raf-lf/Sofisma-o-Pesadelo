using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class Esconderijo : MonoBehaviour
{
    public GameObject hudIcon;
    public Light2D[] hidingLanternLight = new Light2D[2];
    public AudioClip[] doorSFX = new AudioClip[2];
    public SpriteRenderer lightSprite;
    private bool active;
    private bool hiding;


    private void HideUnhide()
    {
        Globals.player.transform.position = new Vector2(transform.position.x, transform.position.y - 0.55f);
        AudioSource audioSource = GetComponent(typeof(AudioSource)) as AudioSource;
        audioSource.PlayOneShot(doorSFX[0], 0.5f);
        audioSource.PlayOneShot(doorSFX[1], 0.5f);

        hiding = !hiding;

        Rigidbody2D rigidbody = Globals.player.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = 0f;
        rigidbody.isKinematic = !rigidbody.isKinematic;

        Collider2D collision = Globals.player.GetComponent(typeof(Collider2D)) as Collider2D;
        collision.enabled = !collision.enabled;

        Animator animator = GetComponent(typeof(Animator)) as Animator;
        if (hiding==true) animator.SetInteger("state", 1);
        else animator.SetInteger("state", 0);

        PauseUnpausePlayer script = Globals.player.GetComponent(typeof(PauseUnpausePlayer)) as PauseUnpausePlayer;
        script.PauseUnpause(false);

        Component[] spriteGroup;
        spriteGroup = Globals.player.GetComponentsInChildren(typeof(SpriteRenderer));
        
        if (spriteGroup != null)
        {
            foreach(SpriteRenderer sprite in spriteGroup)
            {
                sprite.enabled = !sprite.enabled;
            }
        }

        Component[] particleGroup;
        particleGroup = Globals.player.GetComponentsInChildren(typeof(ParticleSystem));
        if (particleGroup != null)
        {
            foreach (ParticleSystem particle in particleGroup)
            {
                var emission = particle.emission;
                emission.enabled = !emission.enabled;
            }
        }

        GameObject lantern = GameObject.Find("PlayerLantern_Lights");


        Component[] lanternLightGroup;
        lanternLightGroup = lantern.GetComponentsInChildren(typeof(Light2D));
        if (lanternLightGroup != null)
        {
            foreach (Light2D light in lanternLightGroup)
            {
                light.enabled = !light.enabled;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D entering)
    {
        if (entering.CompareTag("Player"))
        {
            hudIcon.SetActive(true);
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D entering)
    {
        if (entering.CompareTag("Player") && hiding == false)
        {
            hudIcon.SetActive(false);
            active = false;
        }
    }

    //Update é melhor para detectar inputs!
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && active == true)
        {
            HideUnhide();
        }
    }

    private void FixedUpdate()
    {
        if (hiding == true)
        {
            hidingLanternLight[0].intensity = Globals.LANTERN / 100;
            hidingLanternLight[1].intensity = Globals.LANTERN / 100;

            lightSprite.color = new Color(1, 1, 1, Globals.LANTERN /50);


        }
        else
        {
            if (hidingLanternLight[0].intensity > 0)
            {
                hidingLanternLight[0].intensity -= 0.1f;
                hidingLanternLight[1].intensity -= 0.1f;

                if (hidingLanternLight[0].intensity < 0)
                {
                    hidingLanternLight[0].intensity = 0;
                    hidingLanternLight[1].intensity = 0;
                }
            }

            lightSprite.color = new Color(1, 1, 1, 0);
        }
    }

}
