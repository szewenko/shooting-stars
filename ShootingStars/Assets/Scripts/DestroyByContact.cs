using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int livesValue;
    private GameController gameController;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log (other.name);
        Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.SubLives(livesValue);
			gameController.AddScore(scoreValue);
			if (LevelService.CurrentLives == 0) {
				gameController.GameOver();
				Destroy(other.gameObject);
				Destroy(gameObject);
			}
        }

		if (other.name != "DestroyByBoundary")
		{
			if(gameObject.name.Contains("Asteroid"))
			{
		 	 gameController.AddScore(scoreValue);
			 Destroy(gameObject);
			}
		}
    }
    
}
