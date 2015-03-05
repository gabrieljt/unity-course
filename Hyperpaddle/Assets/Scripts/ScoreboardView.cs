using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ScoreboardView : MonoBehaviour {

	public Scoreboard scoreboard;
	public Text scoresText;
	public Text subtitle;

	void Start () {
		SortedList<int, string> scores = scoreboard.GetScores();

		if (scores.Count > 0) {
			subtitle.text = (scores.Count < 5) ? string.Format("Top {0} Hyperpaddlers of all time!", scores.Count) : "Top 5 Hyperpaddlers of all time!";

			string playerScores = "";		
			foreach(KeyValuePair<int, string> playerScore in scores.Reverse().Take(5)) {
				playerScores += string.Format("{0} <{1}>\n", playerScore.Value, playerScore.Key);
			}

			scoresText.text = playerScores;
		} else {
			subtitle.text = "Best Hyperpaddlers of all time!";
			scoresText.text = "Well... why don't you be the first?";
		}
	}
}
