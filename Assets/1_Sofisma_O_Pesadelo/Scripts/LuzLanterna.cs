using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LuzLanterna : MonoBehaviour
{
    public Light2D light1;
    public Light2D light2;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public int consumo=5;

    // Update is called once per frame
    void Update()
    {

        if (Globals.LANTERN > 0)
        {
            Globals.LANTERN -= Time.deltaTime * consumo;
        }
        light1.pointLightInnerRadius = Globals.LANTERN / 50;
        light1.pointLightOuterRadius = Globals.LANTERN / 25;
        light2.pointLightInnerRadius = Globals.LANTERN / 200;
        light2.pointLightOuterRadius = Globals.LANTERN / 100;
        var em1 = particle1.emission;
        var em2 = particle2.emission;
        em1.rateOverTimeMultiplier = Globals.LANTERN/100;
        em1.rateOverTime = Globals.LANTERN / 20;
        em2.rateOverTime = Globals.LANTERN / 5;
    }
}
