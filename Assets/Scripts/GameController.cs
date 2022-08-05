using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject Hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text restartText;
    public Text gameOverText;
    public Text scoreText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;

        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore ();
        StartCoroutine(Waves()); 
    }

    void update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    IEnumerator Waves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            { 
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (Hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);
            
            if (gameOver)
            {
                restartText.text = "Press 'R' to Restart!";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int NewScoreValue)
    {
        score += NewScoreValue;
        UpdateScore();
    }
    public void LessScore (int NewScoreValue)
    {
        score -= NewScoreValue;
        UpdateScore(); 
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score; 
    }
    public void GameOver()
    {
        gameOverText.text = "GAME OVER!";
        gameOver = true;
    }
}
