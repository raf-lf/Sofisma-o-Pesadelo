using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public KeyCode[] cheatKey = new KeyCode[4];
    public GameObject[] createdObject = new GameObject[2];
    public GameObject cheatAlert;
    private bool cheatModeOn;


    public void Recarga()
    {
        Globals.MAGAZINE += 1;
        Globals.LANTERN += 20;
    }

    public void Criar(int objectId)
    {
        GameObject newObject = Instantiate<GameObject>(createdObject[objectId]);
        if (Globals.player != null) newObject.transform.position = new Vector2(Globals.player.transform.position.x, Globals.player.transform.position.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(cheatKey[0]))
        {
            cheatModeOn = !cheatModeOn;
            cheatAlert.SetActive(!cheatAlert.activeSelf);
        }

        if (Input.GetKeyDown(cheatKey[1]) && cheatModeOn==true)
        {
            Recarga();
        }

        if (Input.GetKeyDown(cheatKey[2]) && cheatModeOn == true)
        {
            Criar(0);
        }

        if (Input.GetKeyDown(cheatKey[3]) && cheatModeOn == true)
        {
            Criar(1);
        }
    }
}
