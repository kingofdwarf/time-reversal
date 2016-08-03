using UnityEngine;
using System.Collections;

public class InputSpawn : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCode;
    [SerializeField]
    private GameObject spawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyUp(this.keyCode))
        {
            GameObject.Instantiate(this.spawn,this.transform.localPosition,this.transform.localRotation);
        }
	}

}
