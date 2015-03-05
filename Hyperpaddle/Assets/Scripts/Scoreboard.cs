using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scoreboard : MonoBehaviour {

	public static int currentTopScore = 0;
	public static SortedList<int, string> topScores = new SortedList<int, string>();

	public void SetCurrentScore (int score) {
		currentTopScore = score;
	}

	public int GetCurrentScore () {
		return currentTopScore;
	}

	public bool IsTopScore (int score) {
		return (score > currentTopScore) ? true : false;
	}

	public void ClaimCurrentScore (string name) {
		topScores.Add(currentTopScore, name);
	}

	public SortedList<int, string> GetScores () {
		return topScores;
	}
}
