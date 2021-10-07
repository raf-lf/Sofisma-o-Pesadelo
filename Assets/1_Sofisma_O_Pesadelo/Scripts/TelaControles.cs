using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaControles : MonoBehaviour
{

	public KeyCode key = KeyCode.Escape;
	public GameObject menu;

	public void OpenCloseMenu()
    {
		//Swap Menu
		menu.SetActive(!menu.activeSelf);

		//Pauseplayer
		PauseUnpausePlayer script = Globals.player.GetComponent(typeof(PauseUnpausePlayer)) as PauseUnpausePlayer;
		script.PauseUnpause(false);

		/*
		//Mute All Sounds
		GameObject camera = GameObject.Find("Main Camera");
		AudioListener audiolistener = camera.GetComponentInChildren(typeof(AudioListener)) as AudioListener;
		audiolistener.enabled = !audiolistener.enabled;
		*/

/*		//Pause Game
		if (Time.timeScale == 0) Time.timeScale = 1;
		else Time.timeScale = 0;
*/
	}

	private void Update()
	{
		if (Input.GetKeyDown(key))
		{
			OpenCloseMenu();
		}
	}
}
