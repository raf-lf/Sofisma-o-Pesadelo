using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Chefe : MonoBehaviour
{
    public int hp;

    //0 - going Up, 1 - going right, 2 - going left
    public int direction = 0;
    public float moveSpeed;
    public float speedIncreaseModifier;
    private float speedIncrease = 0;

    public float spawnDistance = 5;

    public int restCycles = 3;
    public int pounceCycles = 3;
    public int stunCycles = 3;
    public int cycleReductionModifier = 1;
    private int cycleReduction = 0;

    private int cycleCount;

    public Animator animator;
    public AudioSource audioSource;
    public GameObject bossManager;
    public GameObject damageEffect;
    public GameObject roarEffect;
    public GameObject shieldBlock;
    public GameObject shieldBreak;
    public AudioClip roarAudio;

    public void PounceRoar()
    {
        GameObject newObject = Instantiate<GameObject>(roarEffect);
        audioSource.PlayOneShot(roarAudio, 1);
        newObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.y);

    }
    public void Pounce()
    {
        animator.SetBool("damaged", false);
        if (cycleCount < restCycles - cycleReduction) cycleCount += 1;
        else
        {
            cycleCount = 0;
            animator.SetInteger("state", 1);
            PounceRoar();
        }
    }

    public void Rest()
    {
        //Go to rest from Pounce
        if (animator.GetInteger("state") == 1)
        {
            if (cycleCount < pounceCycles - cycleReduction) cycleCount += 1;
            else
            {
                cycleCount = 0;
                animator.SetInteger("state", 0);
            }
        }
        //Go to rest from Stun
        else if (animator.GetInteger("state") == 2)
        {
            if (cycleCount < stunCycles - cycleReduction) cycleCount += 1;
            else
            {
                cycleCount = 0;
                animator.SetInteger("state", 0);
            }
        }
    }

    public void Stun()
    {
        cycleCount = 0;
        animator.SetInteger("state", 2);
    }

    public void Death()
    {
        animator.speed = 1;
        animator.SetInteger("state", 4);

        var script = bossManager.GetComponent(typeof(ChefeBegin)) as ChefeBegin;
        script.End();
    }

    public void Damage()
    {
        GameObject newObject = Instantiate<GameObject>(damageEffect);
        newObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.y); 
        
        if (hp > 1)
            {
                hp -= 1;
                animator.speed += 0.5f;
                audioSource.pitch += 0.1f;

               // cycleReduction += cycleReductionModifier;
                speedIncrease += speedIncreaseModifier;
                cycleCount = 0;
                animator.SetBool("damaged", true);
                animator.SetInteger("state", 0);

            }
            else
            {
                Death();
            }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Anti-Chefe"))
        {
            if (animator.GetInteger("state") == 2)
            {
                Damage();
            }
            else if (animator.GetInteger("state") == 0 || animator.GetInteger("state") == 1)
            {
                GameObject newObject = Instantiate<GameObject>(shieldBlock);
                newObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.y);
                newObject.transform.parent = this.gameObject.transform;

            }

        }
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            if (animator.GetInteger("state") == 0 || animator.GetInteger("state") == 1)
            { 
                Stun();
                GameObject newObject = Instantiate<GameObject>(shieldBreak);
                newObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.y);
                newObject.transform.parent = this.gameObject.transform;
            }
        }

        if (collider.gameObject== Globals.player && animator.GetInteger("state") != 2)
        {
            PlayerDeath script = collider.gameObject.GetComponent(typeof(PlayerDeath)) as PlayerDeath;
            script.Death();
        }
    }


    public void SetLocation()
    {
        if (Globals.player != null)
        {
            switch (direction)
            {
                case (0):
                    this.gameObject.transform.position = new Vector2(Globals.player.transform.position.x, Globals.player.transform.position.y - spawnDistance);
                    break;
                case (1):
                    this.gameObject.transform.position = new Vector2(Globals.player.transform.position.x - spawnDistance, Globals.player.transform.position.y);
                    break;
                case (2):
                    this.gameObject.transform.position = new Vector2(Globals.player.transform.position.x + spawnDistance, Globals.player.transform.position.y);
                    break;
            }
        }
        else 
        {
            this.gameObject.transform.position = new Vector2(0, 1000);
        }
    }

    public void FixedUpdate()
    {
        if (animator.GetInteger("state") == 1)
        {
            switch (direction)
            {
                case (0):
                    Vector2 move1 = new Vector2(0, moveSpeed + speedIncrease);
                    transform.Translate(move1);
                    break;
                case (1):
                    Vector2 move2 = new Vector2(moveSpeed + speedIncrease, 0);
                    transform.Translate(move2);
                    break;
                case (2):
                    Vector2 move3 = new Vector2((moveSpeed + speedIncrease) * -1, 0);
                    transform.Translate(move3);
                    break;
            }
        }
    }
} 
