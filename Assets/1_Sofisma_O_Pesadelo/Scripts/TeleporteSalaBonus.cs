using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporteSalaBonus : MonoBehaviour
{
    public int sala;
    private int sorteio;
    private GameObject teleportTarget;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public GameObject doorReturn;
    public bool retorno;

    public void begin()
    {
        if (retorno == false)
        {
            if (sala == 0) retry();
            else teleport();
        }
        else teleport();
    }

    public void teleport()
    {
        if (retorno == false)
        {
            switch (sala)
            {
                case (1):
                    teleportTarget = door1;
                    break;
                case (2):
                    teleportTarget = door2;
                    break;
                case (3):
                    teleportTarget = door3;
                    break;
                case (4):
                    teleportTarget = door4;
                    break;
                case (5):
                    teleportTarget = door5;
                    break;
            }
        }
        else
        {
            teleportTarget = doorReturn;
        }


        Globals.player.transform.position = new Vector2(teleportTarget.transform.position.x, teleportTarget.transform.position.y);
    }

    public void retry()
    {
        sorteio = (int)Random.Range(1, 6);

        switch (sorteio)
        {
            case (1):
                if (Globals.sala1Pega == true)
                {
                    retry();
                }
                else
                {
                    sala = sorteio;
                    Globals.sala1Pega = true;
                    var script = door1.GetComponent(typeof(TeleporteSalaBonus)) as TeleporteSalaBonus;
                    script.doorReturn = this.gameObject;
                }
                break;

            case (2):
                if (Globals.sala2Pega == true)
                {
                    retry();
                }
                else
                {
                    sala = sorteio;
                    Globals.sala2Pega = true;
                    var script = door2.GetComponent(typeof(TeleporteSalaBonus)) as TeleporteSalaBonus;
                    script.doorReturn = this.gameObject;
                }
                break;

            case (3):
                if (Globals.sala3Pega == true)
                {
                    retry();
                }
                else
                {
                    sala = sorteio;
                    Globals.sala3Pega = true;
                    var script = door3.GetComponent(typeof(TeleporteSalaBonus)) as TeleporteSalaBonus;
                    script.doorReturn = this.gameObject;
                }
                break;

            case (4):
                if (Globals.sala4Pega == true)
                {
                    retry();
                }
                else
                {
                    sala = sorteio;
                    Globals.sala4Pega = true;
                    var script = door4.GetComponent(typeof(TeleporteSalaBonus)) as TeleporteSalaBonus;
                    script.doorReturn = this.gameObject;
                }
                break;

            case (5):
                if (Globals.sala5Pega == true)
                {
                    retry();
                }
                else
                {
                    sala = sorteio;
                    Globals.sala5Pega = true;
                    var script = door5.GetComponent(typeof(TeleporteSalaBonus)) as TeleporteSalaBonus;
                    script.doorReturn = this.gameObject;
                }
                break;
        }
        print("Porta foi vinculada com a porta " + sorteio);
        teleport();
    }

}
