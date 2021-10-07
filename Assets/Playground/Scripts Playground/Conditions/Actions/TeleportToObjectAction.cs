using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/TeleportToObject")]
public class TeleportToObjectAction : Action
{
	public GameObject objectToMove;
	public GameObject targetObject;
	public bool stopMovements = true;


	// Moves the GameObject instantly to a custom position
	public override bool ExecuteAction(GameObject dataObject)
	{
		Rigidbody2D rb2D;

		if (objectToMove != null)
		{
			//moves the specified object
			objectToMove.transform.position = new Vector2(targetObject.transform.position.x, targetObject.transform.position.y);
			rb2D = objectToMove.GetComponent<Rigidbody2D>();
		}
		else
		{
			//moves this object
			transform.position = new Vector2(targetObject.transform.position.x, targetObject.transform.position.y);
			rb2D = transform.GetComponent<Rigidbody2D>();
		}
		
		objectToMove.transform.position = new Vector2(targetObject.transform.position.x, targetObject.transform.position.y);


		//in case the object has physics, we can bring it to an halt
		if (stopMovements
			&& rb2D != null)
		{
			rb2D.velocity = Vector3.zero;
			rb2D.angularVelocity = 0f;
		}

		return true;
	}
}
