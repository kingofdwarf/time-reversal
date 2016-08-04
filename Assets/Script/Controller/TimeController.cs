using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour
{
	public StateRecorder recorder;
	public StatePlayer player;

    public int index;

    private bool isForward;
    private bool stop;
    void Awake()
    {
        this.isForward = true;
        this.stop = false;
    }

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
       if(Input.GetKeyUp(KeyCode.Z))
        {
            this.isForward = !this.isForward;
            this.stop = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
			Debug.Log ("Rewinding:Enter");
            this.isForward = false;
            this.stop = false;

			if (player != null && recorder != null) 
			{
				recorder.StopRecord ();
				player.SetRecordData (recorder.recordData);
				player.GetComponent<Rigidbody2D> ().isKinematic = true;
				player.Play (this.index - 1);
			}
				
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
			Debug.Log ("Rewinding:Leave");
            this.isForward = true;
            this.stop = false;

			if (player != null && recorder != null) 
			{
				player.Stop ();
				player.GetComponent<Rigidbody2D> ().isKinematic = false;
				recorder.StartRecord (this.index);
			}
        }
    }

    void FixedUpdate()
    {
        if (this.stop == true) return;
        if( isForward )
            this.index++;
        else
        {
            if (this.index-- < 0)
                this.index = 0;
        }
    }

    public void Stop()
    {
        this.stop = true;
    }

    
    
}
