using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public Text scoreText;
	private int score = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		scoreText.text = score.ToString();
	}

	void Add (int points) {
		score += points;
		scoreText.text = score.ToString();
	}

	int GetScore () {
		return score;
	}
}
