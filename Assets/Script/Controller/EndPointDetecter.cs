using UnityEngine;
using System.Collections;

public class EndPointDetecter : MonoBehaviour {
    private Transform groundCheck;
    void Awake()
    {
        groundCheck = transform.Find("groundCheck");
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("EndPoint")))
            {
                var levelController = GameObject.FindObjectOfType<LevelController>();
                levelController.LevelComplete();
            }
        }
    }
}
