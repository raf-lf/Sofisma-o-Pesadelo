using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUnpausePlayer : MonoBehaviour
{
    public void PauseUnpause(bool stopScripts)
    {

        Rigidbody2D rigidbody = Globals.player.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = 0f;
            
        Component[] animators;
        animators = GetComponentsInChildren(typeof(Animator));
        foreach (Animator animator in animators)
        {
            animator.SetBool("move", false);
        }

        Component[] scripts1;
        scripts1 = GetComponentsInChildren(typeof(ConditionKeyPress));
        foreach (ConditionKeyPress script in scripts1)
        {
            script.enabled = !script.enabled;
        }

        Component[] shooters;
        shooters = GetComponentsInChildren(typeof(ObjectResourceShooter));
        foreach (ObjectResourceShooter shooter in shooters)
        {
            shooter.enabled = !shooter.enabled;
        }

        PickUpAndHold pickup = GetComponent(typeof(PickUpAndHold)) as PickUpAndHold;
        pickup.enabled = !pickup.enabled;

        MoveWithArrowsConstantSpeed movement = GetComponent(typeof(MoveWithArrowsConstantSpeed)) as MoveWithArrowsConstantSpeed;
        movement.enabled = !movement.enabled;

        if (stopScripts == true)
        {
            Nictofobia nictofobia = GetComponent(typeof(Nictofobia)) as Nictofobia;
            nictofobia.enabled = !nictofobia.enabled;

            LuzLanterna lanterna = GetComponentInChildren(typeof(LuzLanterna)) as LuzLanterna;
            lanterna.enabled = !lanterna.enabled;
        }
    }

}
