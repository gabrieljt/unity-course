﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreboardView : MonoBehaviour {

	public Scoreboard scoreboard;
	public Text scoresText;

	void Start () {
		SortedList<int, string> scores = scoreboard.GetScores();

		if (scores.Count > 0) {
		string playerScores = "";
		foreach(KeyValuePair<int, string> playerScore in scores) {
			playerScores += string.Format("{0} <{1}>\n", playerScore.Value, playerScore.Key);
		}

		scoresText.text = playerScores;
		} else {
			scoresText.text = "Well... why don't you be the first?";
		}
	}
}