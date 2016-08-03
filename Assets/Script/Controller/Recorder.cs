using UnityEngine;
using System.Collections;

public abstract class Recorder : MonoBehaviour
{
	[SerializeField]
	protected TimeController timeController;

	protected bool recording;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyUp(KeyCode.R))
		{
			StartRecord ();
		}

		if (Input.GetKeyUp(KeyCode.S))
		{
			StopRecord();
		}

		if (recording)
			Record ();
	}

	public abstract void Record();

	public virtual void StartRecord ()
	{
		recording = true;
		this.timeController.index = 0;
	}

	public virtual void StopRecord()
	{
		recording = false;
	}

}

