using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour
{
    public int index;

    private bool isForward;

    void Awake()
    {
        this.isForward = true;
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
        }
	}

    void FixedUpdate()
    {
        if( isForward )
            this.index++;
        else
        {
            if (this.index-- < 0)
                this.index = 0;
        }
    }
    
}
