using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDAmmo : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    public GameObject t5;

    // Update is called once per frame
    void FixedUpdate()
    {
        updateAmmo(1, t1);
        updateAmmo(2, t2);
        updateAmmo(3, t3);
        updateAmmo(4, t4);
        updateAmmo(5, t5);

    }

    private void updateAmmo (int ammo, GameObject ammoHud)
    {
        if (Globals.MAGAZINE >= ammo)
        {
            ammoHud.SetActive(true);
        }
        else
        {
            ammoHud.SetActive(false);
        }
    }
}
//           sr.enabled = !sr.enabled;
