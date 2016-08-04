using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public struct InputState
{
	public List<KeyCode> keyCode;
}

public class InputRecorder : Recorder
{
	private Dictionary<int, InputState> recordData= new Dictionary<int, InputState>();

	public override void StartRecord (int index = 0)
	{
		base.StartRecord (index);
		//init
		this.recordData = new Dictionary<int, InputState>();
		RecordContainer.inputRecords.Add(this.recordData);
	}

	public override void StopRecord ()
	{
		base.StopRecord ();

	}

	public override void Record ()
	{
		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown (kcode)) 
			{
				if (recordData.ContainsKey(this.timeController.index)) {
					recordData[this.timeController.index].keyCode.Add (kcode);

				} else {
					var keyCode = new List<KeyCode> ();
					keyCode.Add (kcode);
					recordData.Add(this.timeController.index, new InputState () {
						keyCode = keyCode
					});
				}
			}
		}


		//Debug.Log("Recorded index:"  + this.timeController.index);
	}

}

