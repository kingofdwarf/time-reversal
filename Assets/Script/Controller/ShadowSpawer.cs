using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecordContainer
{
    public static List<Dictionary<int, PlayerState>> records = new List<Dictionary<int, PlayerState>>();

    public static void Clear()
    {
        records.Clear();
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
            GameObject.Destroy(sceneShadows[0].gameObject);
            sceneShadows.RemoveAt(0);
        }
        sceneShadows.Clear();
    }

    public void SpawnAll()
    {
        int i = 0;
        foreach(var record in RecordContainer.records)
        {
            var shadow = GameObject.Instantiate(this.shadow.gameObject);
            shadow.name = "Shadow_" + (i++);
            shadow.transform.localPosition = this.transform.localPosition;
            shadow.transform.localRotation = this.transform.localRotation;
            var statePlayer= shadow.GetComponent<StatePlayer>();
            statePlayer.SetRecordData(record);
            statePlayer.Play();
            sceneShadows.Add(statePlayer);
        }
    }

}
