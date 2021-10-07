using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Mancho : MonoBehaviour
{
    public AudioClip[] SFX = new AudioClip[2];
    private Animator animator;
    private AudioSource audioSource;
    public bool patrols = false;
    private bool moving = true;
    public Vector2 movementSpeed;

    public void Idle()
    {
        moving = true;
        animator.SetInteger("state", 0);
    }

    public void Attack()
    {
        moving = false;
        audioSource.PlayOneShot(SFX[0], 1);
        animator.SetInteger("state", 1);
    }

    public void Death()
    {
        moving = false;
        audioSource.PlayOneShot(SFX[1], 1);
        animator.SetInteger("state", 2);
    }

    public void Turn()
    {
        movementSpeed *= -1;
        Vector2 objTransform = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.localScale = objTransform;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Globals.player)
        {
            Attack();
        }

        if (collision.gameObject.CompareTag("Patrulha")==true)
        {
            Turn();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Globals.player)
        {
            PlayerDeath script = collision.gameObject.GetComponent(typeof(PlayerDeath)) as PlayerDeath;
            script.Death();
        }

        if (collision.gameObject.CompareTag("Bullet") == true)
        {
            Death();
        }

        if (patrols == true && moving == true) 
        {
            Turn();
        }
    
    }

    private void Start()
    {
        animator = GetComponent(typeof(Animator)) as Animator;
        audioSource = GetComponent(typeof(AudioSource)) as AudioSource;
    }

    private void FixedUpdate()
    {
        if (patrols == true && moving == true)
            {
            transform.Translate(movementSpeed);
            }
        }

}
