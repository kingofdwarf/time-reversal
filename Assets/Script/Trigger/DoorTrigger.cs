using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour 
{
	public DoorController endPoint;

	// Use this for initialization
	void Start () 
	{
		endPoint.Close ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer ("Player"))
		{
			Debug.Log ("Hit by a Player.");
			endPoint.Open ();
		}


	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer ("Player"))
		{
			Debug.Log ("Hit by a Player.");
			endPoint.Open ();

		}
	}
}
