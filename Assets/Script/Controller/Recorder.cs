using UnityEngine;
using System.Collections;

public abstract class Recorder : MonoBehaviour
{
	[SerializeField]
	protected TimeController timeController;
    [SerializeField]
    private bool SelfControl;

    protected bool recording;
	// Use this for initialization
	void Start ()
	{
        if (!SelfControl)
        {
            StartRecord();
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(SelfControl)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                StartRecord();
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                StopRecord();
            }
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

