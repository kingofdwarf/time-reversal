using UnityEngine;
using System.Collections;

public class PlayerWallTrigger : MonoBehaviour 
{

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("PlayerWall");
		if (col.gameObject.layer == LayerMask.NameToLayer ("PlayerWall")) 
		{
			this.GetComponent<Rigidbody2D> ().isKinematic = false;
			this.GetComponent<Rigidbody2D> ().gravityScale = 0;

		}
	}
}
