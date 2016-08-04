using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Animator))]
public class StatePlayer : MonoBehaviour
{
    [SerializeField]
    private  TimeController timeController;
      
    private Dictionary<int, PlayerState> recordData = new Dictionary<int, PlayerState>();
    private bool isPlaying;
    private Animator animator;

    void Awake()
    {
        this.animator = this.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isPlaying)
        {
            if (this.recordData.ContainsKey(this.timeController.index))
            {   
				//Debug.Log ("play :" + this.timeController.index);
                var playerState = this.recordData[this.timeController.index];
                this.transform.position = playerState.postion;
                this.transform.rotation = playerState.quaternion;

                this.transform.localScale = playerState.scale;

                this.animator.Play(playerState.animateState);
			}else if(this.timeController.index > this.recordData.Last().Key)
			{
				//Debug.Log ("STOPP!!");
				this.timeController.index = this.recordData.Last().Key;
				this.timeController.Stop();
			}
        }
    }

    public void SetRecordData(Dictionary<int,PlayerState> recordData)
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
