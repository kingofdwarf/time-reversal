using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerControl))]
public class ActionPlayer : MonoBehaviour
{
	[SerializeField]
	private  TimeController timeController;

	private Dictionary<int, ActionState> recordData = new Dictionary<int, ActionState>();
	private bool isPlaying;

	private PlayerControl playerControll;

	void Awake()
	{
		playerControll = this.GetComponent<PlayerControl> ();

	}

	// Use this for initialization
	void Start ()
	{
		if (Input.GetKeyUp(KeyCode.P))
		{
			this.isPlaying = true;
			this.timeController.index = 0;
		}
	}
	
	void FixedUpdate()
	{
		if (isPlaying)
		{
			if(this.recordData.ContainsKey(this.timeController.index))
			{
				var action = this.recordData [this.timeController.index];
				switch (action.type) 
				{
					case ActionType.Move:
						playerControll.Move (action.value);
					break;
					case ActionType.Jump:
						playerControll.Jump ();
					break;
					case ActionType.None:
						
					break;

				}

			}
		}
	}

	public void SetRecordData(Dictionary<int,ActionState> recordData)
	{
		this.recordData = recordData;
	}


}

