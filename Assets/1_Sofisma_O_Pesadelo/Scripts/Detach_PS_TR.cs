using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detach_PS_TR : MonoBehaviour
{
    public GameObject targetObject;

    public void run()
    {
        if (targetObject == null)
        {
            targetObject = this.gameObject;
        }
        //Gets all particles systems in object and children and detach and stop emission
        Component[] particles;
        particles = targetObject.GetComponentsInChildren(typeof(ParticleSystem));  
        if (particles != null)
        {
            foreach (ParticleSystem particle in particles)
            {
                //desvincula objeto no qual o componente está do objeto pai
                particle.transform.parent = null;
                //interrompe a emissão de novas partículas
                particle.Stop();
                //deleta o objeto no qual o componente está depois que a duração do componente acabar
                Destroy(particle.gameObject, particle.main.duration);
            }
        }

        //Gets all trail renderes in object and children and detach
        Component[] trails;
        trails = targetObject.GetComponentsInChildren(typeof(TrailRenderer));

        if (trails != null)
        {
            foreach (TrailRenderer trail in trails)
            { 
            trail.transform.parent = null;
                Destroy(trail.gameObject, trail.time);
            }
        }
    }
}
