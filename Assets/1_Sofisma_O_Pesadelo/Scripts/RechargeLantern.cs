using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeLantern : MonoBehaviour
{
    public int ammount;
    public bool additive;
    // Start is called before the first frame update
    public void Recharge()
    {
        if (additive == true)
        {
            Globals.LANTERN = Globals.LANTERN + ammount;
        }
        else
        {
            Globals.LANTERN = ammount;
        }

    }
}
