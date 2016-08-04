using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IInputListener
{
	void Move(float moveForce);
	void Jump();
	void Fire();
}

public class InputController : MonoBehaviour
{
	public List<IInputListener> listeners = new List<IInputListener>();

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			foreach(var listenr in listeners)
			{
				listenr.Jump ();
			}
		}

		if (Input.GetButtonDown ("Fire1")) 
		{
			foreach(var listenr in listeners)
			{
				listenr.Fire ();
			}
		}
        
	}

	void FixedUpdate()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		foreach(var listenr in listeners)
		{
			listenr.Move (h);
		}

	}

	public void AddListener(IInputListener listener)
	{
		if (!this.listeners.Contains (listener)) {
			this.listeners.Add (listener);
		} else {
			Debug.Log ("Repeatible listener!" + listener.ToString());
		}
	}

	public void RemoveListener(IInputListener listener)
	{
		if (this.listeners.Contains (listener)) 
		{
			this.listeners.Remove (listener);
		} else {
			Debug.Log (listener.ToString() + " not found, can't remove listen.");
		}
	}
}

