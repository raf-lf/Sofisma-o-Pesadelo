using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeMagazine : MonoBehaviour
{
    public int ammount;
    public bool additive;
    // Start is called before the first frame update
    public void Recharge()
    {
        if (additive==true)
        {
            Globals.MAGAZINE = Globals.MAGAZINE + ammount;
        }
        else 
        {
            Globals.MAGAZINE = ammount;
        }
        
    }
}
