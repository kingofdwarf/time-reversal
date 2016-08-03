using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public struct PlayerState
{
    public Vector3 postion;
    public int animateState;
    public Quaternion quaternion;
    public bool direction;

    public override string ToString()
    {
        return "player position: " + this.postion + " direction : " + direction + " animateState:" + animateState;
    }

}

[RequireComponent(typeof(Animator))]
public class StateRecorder : Recorder
{
    [SerializeField]
    private StatePlayer player;

    private Animator animator;

	private Dictionary<int, PlayerState> recordData= new Dictionary<int, PlayerState>();
     
    void Awake()
    {
        this.animator = this.GetComponent<Animator>();
    }

    // Use this for initialization
	void Start()
	{
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
    }

	public override void StartRecord ()
	{
		base.StartRecord ();
		//init
		this.recordData = new Dictionary<int, PlayerState>();
		player.SetRecordData(this.recordData);
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
			direction = this.transform.localScale.x > 0,
			quaternion = this.transform.rotation
		};
		//Debug.Log("Recorded index:"  + this.timeController.index);
		//Debug.Log(this.recordData[this.timeController.index].ToString());
	}

}
