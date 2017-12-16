using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
	public Text levelText;
    public Text livesText;

    private bool gameOver;
    private bool restart;
    static public int score;
    static public int lives;

    void Start()
    {
        score = 0;
        lives = 3;
        gameOver = false;
        restart = false;
		LevelService.IsEnemiesCreationAllowed = true;
		LevelService.CurrentLevel = 1;

        restartText.text = "";
        gameOverText.text = "";
		levelText.text = "";

        UpdateScore();
        UpdateLives();
        StartCoroutine (SpawnVawes());
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("_Scenes/Main_menu");
        }


        if (restart)
        {
            SceneManager.LoadScene("_Scenes/Game_over_menu");
        }
    }

	IEnumerator SpawnVawes(float customSpawnWait = 0.00f, int customHazardCount = 0)

    {
		int count = customHazardCount != default(int) ? customHazardCount :hazardCount;
		float wait = customSpawnWait != default(float) ? customSpawnWait : spawnWait;
        yield return new WaitForSeconds(startWait);
		int waveCounter = 0;
		while (waveCounter < 3)
        {
			waveCounter++;
			for (int i = 0; i < count; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(wait);
            }

            yield return new WaitForSeconds(waveWait);

			if (gameOver) {
				restart = true;
				break;
			}
        }


		if (waveCounter == 3) {
			LevelService.IsNextLevelProcessingStarted = true;
		}

		UpdateScore ();
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
		StartCoroutine (UpdateCoroutine());
    }

    public void SubLives(int newLivesValue)
    {
        lives -= newLivesValue;
        UpdateLives();
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }

    public void GameOver() {
        gameOver = true;
    }

	private IEnumerator UpdateCoroutine()
	{
		LevelService.CurrentScore = score;
        LevelService.CurrentLives = lives;
        scoreText.text = "Score: " + LevelService.CurrentScore.ToString();
        livesText.text = "Lives: " + LevelService.CurrentLives.ToString();
        if (LevelService.IsNextLevelProcessingStarted) {
			LevelService.IsNextLevelProcessingStarted = false;	
			yield return new WaitForSeconds (4);
			LevelService.CurrentLevel++;
			levelText.text = "Level " + (LevelService.CurrentLevel).ToString();
			yield return new WaitForSeconds (2);
			levelText.text = "";
			LevelService.IsNextLevelProcessingStarted = false;
			if (LevelService.CurrentLevel > 1) {
				levelText.text = LevelService.CurrentLevel == 3 ? "Watch out !" : string.Empty;
				yield return new WaitForSeconds (2);
				levelText.text = "";		
				StartCoroutine (SpawnVawes (0.4f / LevelService.CurrentLevel, LevelService.CurrentLevel * 10));
			} else {
				
				StartCoroutine (SpawnVawes ());
			}
		}
	}
}
