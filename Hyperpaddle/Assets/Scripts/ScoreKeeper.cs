using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public LevelManager levelManager;
	public Scoreboard scoreboard;
	public Text currentScoreText;
	public Text highestScoreText;
	private int score = 0;

	void Start () {
		DontDestroyOnLoad(gameObject);
		currentScoreText.text = score.ToString();
	}

	public void Add (int points) {
		score += points;
		currentScoreText.text = score.ToString();
	}

	int GetScore () {
		return score;
	}

	public void BallOut () {
		if (scoreboard.IsHighScore(score)) {
			levelManager.LoadLevel("Enter Name");
		} else {
			levelManager.LoadLevel("Lose Menu");
		}
	}
}
