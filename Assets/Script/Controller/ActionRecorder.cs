using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct ActionState
{
	public ActionType type;
	public float value;
}

public enum ActionType
{
	None,
	Move,
	Jump
}

public class ActionRecorder : Recorder, IInputListener
{
	[SerializeField]
	private ActionPlayer player;
	private Dictionary<int, ActionState> recordData= new Dictionary<int, ActionState>();

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void Move(float inputForce)
	{
		//record player state
		this.recordData[this.timeController.index] = new ActionState()
		{
			type = ActionType.Move,
			value = inputForce
		};
	}

	public void Jump()
	{
		//record player state
		this.recordData[this.timeController.index] = new ActionState()
		{
			type  = ActionType.Jump,
			value = 0
		};
	}

	public override void StartRecord ()
	{
		base.StartRecord ();
		//init
		this.recordData = new Dictionary<int, ActionState>();
		player.SetRecordData (this.recordData);
        
    }

	public override void StopRecord ()
	{
		base.StopRecord ();
	}

	public override void Record ()
	{
		//Debug.Log("Recorded index:"  + this.timeController.index);
		//Debug.Log(this.recordData[this.timeController.index].ToString());
	}

}

