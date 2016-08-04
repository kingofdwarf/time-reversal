using UnityEngine;
using System.Collections;

public class WallTrigger : MonoBehaviour 
{
	[SerializeField]
	private GameObject wall;
	[SerializeField]
	public float hideDuration = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer ("Bombs"))
		{
			Debug.Log ("Hit by a bomb.");
			StartCoroutine (WallHideAndShow());

		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer ("Bombs"))
		{
			Debug.Log ("Hit by a bomb.");
			StartCoroutine (WallHideAndShow());

		}
	}

	IEnumerator WallHideAndShow()
	{
		this.GetComponent<Animator> ().SetBool("Open",true);
		wall.SetActive (false);
		yield return new WaitForSeconds (hideDuration);
		wall.SetActive (true);
		this.GetComponent<Animator> ().SetBool("Open",false);
	}
}
