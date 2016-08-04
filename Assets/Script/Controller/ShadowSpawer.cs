using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecordContainer
{
    public static List<Dictionary<int, PlayerState>> records = new List<Dictionary<int, PlayerState>>();
	public static List<Dictionary<int, InputState>>  inputRecords = new List<Dictionary<int, InputState>>();

    public static void Clear()
    {
        records.Clear();
		inputRecords.Clear ();
    }

}

public class ShadowSpawer : MonoBehaviour
{
    [SerializeField]
    private StatePlayer shadow;

    private List<StatePlayer> sceneShadows = new List<StatePlayer>();
    // Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyUp(KeyCode.Q))
        {
            DestroyAll();
            SpawnAll();
        }
	}

    public void DestroyAll()
    {
        while (sceneShadows.Count > 0)
        {
			if(sceneShadows[0]!= null)
	            GameObject.Destroy(sceneShadows[0].gameObject);
            sceneShadows.RemoveAt(0);
        }
        sceneShadows.Clear();
    }

    public void SpawnAll()
    {
		for(var i = 0 ; i < RecordContainer.records.Count; i++)
        {
			var record = RecordContainer.records [i];

            var shadow = GameObject.Instantiate(this.shadow.gameObject);
            shadow.name = "Shadow_" + (i);
            shadow.transform.localPosition = this.transform.localPosition;
            shadow.transform.localRotation = this.transform.localRotation;
            var statePlayer= shadow.GetComponent<StatePlayer>();
            statePlayer.SetRecordData(record);
            statePlayer.Play();

			if (RecordContainer.inputRecords.Count - 1 >= i) 
			{
				Debug.Log ("Input Record");
				var input = RecordContainer.inputRecords [i];
				var inputPlayer= shadow.GetComponent<InputPlayer>();
				inputPlayer.SetRecordData(input);
				inputPlayer.Play();
			}

            sceneShadows.Add(statePlayer);
        }
    }

}
