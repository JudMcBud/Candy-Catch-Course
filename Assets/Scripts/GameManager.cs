using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	int score = 0;
	int lives = 3;
	
	bool gameOver = false;
	
	public GameObject livesPanel;
	public GameObject scorePanel;
	public GameObject gameOverPanel;
	
	public static GameManager instance;
	
	public Text scoreText;
	public Text gameOverScore;
	
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void IncrementScore()
	{
		if(!gameOver)
		{
		score++;
		scoreText.text = score.ToString();
			//print(score);
		}
	}
	
	public void DecrementLives()
	{
		if(lives > 0)
		{
			lives--;
			
			livesPanel.transform.GetChild(lives).gameObject.SetActive(false);
		}
		
		if(lives <= 0)
		{
			gameOver = true;
			
			GameOver();
		}
	}
	
	public void GameOver()
	{
		
		CandySpawner.instance.StopSpawningCandies();
		GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
		livesPanel.SetActive(false);
		scorePanel.SetActive(false);
		gameOverPanel.SetActive(true);
		gameOverScore.text = score.ToString();
		print("GameOver");
	}
	
	public void Restart()
	{
		SceneManager.LoadScene("Game");
	}
	
	public void BackToMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
