using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scoreboard : MonoBehaviour {

	void SetCurrentScore (int score) {
	}

	public bool IsHighScore (int score) {
		return false;
	}

	void ClaimCurrentScore (string name) {
	}

	SortedList<int, string> GetScores () {
		return new SortedList<int, string>();
	}
}
