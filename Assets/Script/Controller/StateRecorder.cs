using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public struct PlayerState
{
    public Vector3 postion;
    public int animateState;
    public Quaternion quaternion;
    public Vector3 scale;

    public override string ToString()
    {
        return "player position: " + this.postion + " scale : " + scale + " animateState:" + animateState;
    }

}

[RequireComponent(typeof(Animator))]
public class StateRecorder : Recorder
{
    private Animator animator;

	public  Dictionary<int, PlayerState> recordData= new Dictionary<int, PlayerState>();
     
    void Awake()
    {
        this.animator = this.GetComponent<Animator>();
    }

	public override void StartRecord (int index = 0)
	{
		base.StartRecord (index);
		//init
		this.recordData = new Dictionary<int, PlayerState>();
        RecordContainer.records.Add(this.recordData);
    }

	public override void StopRecord ()
	{
		base.StopRecord ();
        
    }

	public override void Record ()
	{
       
		//record player state
		this.recordData[this.timeController.index] = new PlayerState()
		{
			postion = this.transform.position,
			animateState = this.animator.isActiveAndEnabled ? this.animator.GetCurrentAnimatorStateInfo(0).shortNameHash : 0,
            scale = this.transform.localScale,
			quaternion = this.transform.rotation
		};
		//Debug.Log("Recorded index:"  + this.timeController.index);
		//Debug.Log(this.recordData[this.timeController.index].ToString());
	}

}
