using UnityEngine;
using System.Collections;

public class DeadTrigger : MonoBehaviour
{
    public GameObject splash;
    public LevelController levelController;
    void OnTriggerEnter2D(Collider2D col)
    {
		Debug.Log (col.name);
		Dead(col.gameObject);
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log (col.gameObject.name);
		Dead (col.gameObject);
	}

	void Dead(GameObject col)
	{
		// If the player hits the trigger...
		if (col.gameObject.tag == "Player")
		{

			// ... instantiate the splash where the player falls in.
			Instantiate(splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			col.transform.position = new Vector3(-100,0,0);
			// ... reload the level.
			StartCoroutine("ReloadGame");
		}
		else
		{
			// ... instantiate the splash where the enemy falls in.
			Instantiate(splash, col.transform.position, transform.rotation);

			// Destroy the enemy.
			Destroy(col.gameObject);
		}
	}

    IEnumerator ReloadGame()
    {
        yield return new WaitForSeconds(2);
        levelController.LevelReset();
    }
}
