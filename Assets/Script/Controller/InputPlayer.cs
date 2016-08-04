using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class InputPlayer : MonoBehaviour
{
	[SerializeField]
	private  TimeController timeController;

	private Dictionary<int, InputState> recordData = new Dictionary<int, InputState>();
	private bool isPlaying;

	void FixedUpdate()
	{
		if (isPlaying)
		{

			if (this.recordData.ContainsKey(this.timeController.index))
			{   
				var inputState = this.recordData[this.timeController.index];
				PlayInput (inputState);

			}else if(this.timeController.index > this.recordData.Last().Key)
			{
				this.timeController.index = this.recordData.Last().Key;
				this.timeController.Stop();
			}
		}
	}

	public abstract void PlayInput (InputState inputState);

	public void SetRecordData(Dictionary<int,InputState> recordData)
	{
		this.recordData = recordData;
	}

	public void Play(int index=0)
	{
		this.isPlaying = true;
		this.timeController.index = index;
	}

	public void Stop()
	{
		this.isPlaying = false;
	}
}

