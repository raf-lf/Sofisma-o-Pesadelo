using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerObject : MonoBehaviour
{
    public void Start()
    {
        Globals.player = this.gameObject;
        print("Player object now is: " + Globals.player);
    }
}
