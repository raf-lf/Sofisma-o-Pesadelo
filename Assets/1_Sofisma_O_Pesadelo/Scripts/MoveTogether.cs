using UnityEngine;
using System.Collections;

public class MoveTogether : MonoBehaviour
{
	public GameObject objecttoFollow;


	// Moves the GameObject instantly to a custom position
	void Update()
	{
		//Rigidbody2D rb2D;
		this.gameObject.transform.position = new Vector2(objecttoFollow.transform.position.x,objecttoFollow.transform.position.y);
//			rb2D = objectToMove.GetComponent<Rigidbody2D>();


	}
}
