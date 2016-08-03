using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    void Update()
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
                var playerState = this.recordData[this.timeController.index];
                this.transform.position = playerState.postion;
                this.transform.rotation = playerState.quaternion;
                this.animator.Play(playerState.animateState);
            }
        }
    }

    public void SetRecordData(Dictionary<int,PlayerState> recordData)
    {
        this.recordData = recordData;
    }
}
