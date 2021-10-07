using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefeSwitch : MonoBehaviour
{
    public GameObject switchOrganizer;
    public GameObject spawnedItem;
    public GameObject hudIcon;
    public KeyCode key = KeyCode.Q;
    private bool active;


    public void OnTriggerEnter2D(Collider2D entering)
    {
        if (entering.CompareTag("Player"))
        {
            hudIcon.SetActive(true);
            active = true;
        }
    }

    public void OnTriggerExit2D(Collider2D entering)
    {
        if (entering.CompareTag("Player"))
        {
            hudIcon.SetActive(false);
            active = false;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(key) && active==true)
        {
            GameObject newObject = Instantiate<GameObject>(spawnedItem);
            newObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.25f, this.gameObject.transform.position.y);

            var script = switchOrganizer.GetComponent(typeof(ChefeSwitchOrganizer)) as ChefeSwitchOrganizer;
            script.Sorteio(0);
            active = false;
        }
    }
}
