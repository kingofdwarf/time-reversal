using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string nextLevel;

    [SerializeField]
    private ShadowSpawer shadowSpawer;
    [SerializeField]
    private Recorder player;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LevelReset();
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            player.StopRecord();
            shadowSpawer.DestroyAll();
            shadowSpawer.SpawnAll();
            player.transform.localPosition = shadowSpawer.transform.localPosition;
            player.StartRecord();
        }

    }

    public void LevelReset()
    {
        RecordContainer.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelComplete()
    {
        RecordContainer.Clear();
        SceneManager.LoadScene(nextLevel);
    }

}
