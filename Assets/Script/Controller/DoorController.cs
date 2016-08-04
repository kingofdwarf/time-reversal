using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
	private bool open;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Open()
	{
		open = true;
		this.gameObject.layer = LayerMask.NameToLayer ("EndPoint");
	}

	public void Close()
	{
		open = false;
		this.gameObject.layer = LayerMask.NameToLayer ("Default");
	}

}

