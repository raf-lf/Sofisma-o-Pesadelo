using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefeSwitchOrganizer : MonoBehaviour
{
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;
    public GameObject switch5;
    private int sorteio;
    private int sorteioAnterior;

    public void OnOff(GameObject bulb, bool on)
    {
        Animator anim;
        anim = bulb.GetComponent<Animator>();
        
        if (on==true) anim.SetBool("on", true);
        else anim.SetBool("on", false);
    }

    public void Sorteio(int forceValue)
    {
        OnOff(switch1, false);
        OnOff(switch2, false);
        OnOff(switch3, false);
        OnOff(switch4, false);
        OnOff(switch5, false);


        if (forceValue == 0)
        {
            sorteio = (int)Random.Range(1, 6);
            if (sorteioAnterior == sorteio) Sorteio(0);
        }
        else
        {
            sorteio = forceValue;
        }


        switch(sorteio)
        {
            case(1):
                OnOff(switch1, true);
                break;
            case(2):
                OnOff(switch2, true);
                break;
            case(3):
                OnOff(switch3, true);
                break;
            case(4):
                OnOff(switch4, true);
                break;
            case(5):
                OnOff(switch5, true);
                break;
        }
  //      print("Bulbo nº"+sorteio+ " sorteado. Sorteio anterior foi "+sorteioAnterior+".");
        sorteioAnterior = sorteio;

    }

    public void AllOff()
    {
        OnOff(switch1, false);
        OnOff(switch2, false);
        OnOff(switch3, false);
        OnOff(switch4, false);
        OnOff(switch5, false);
    }

}
