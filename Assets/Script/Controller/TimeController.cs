using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour
{
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
            this.isForward = false;
            this.stop = false;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            this.isForward = true;
            this.stop = false;
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
