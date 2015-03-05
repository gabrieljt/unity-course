using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LocalScoreboard : MonoBehaviour {

	private class ScoreboardData {
		public int currentTopScore = 0;
		public SortedList<int, string> topScores = new SortedList<int, string>();
	}

	private ScoreboardData scoreData;
	private string filePath;

	public void SetCurrentScore (int score) {
		scoreData.currentTopScore = score;
	}
	
	public int GetCurrentScore () {
		return scoreData.currentTopScore;
	}
	
	public bool IsTopScore (int score) {
		return (score > scoreData.currentTopScore) ? true : false;
	}
	
	public void ClaimCurrentScore (string name) {
		scoreData.topScores.Add(scoreData.currentTopScore, name);
	}
	
	public SortedList<int, string> GetScores () {
		return scoreData.topScores;
	}

	void Awake () {
		scoreData = new ScoreboardData();
		filePath = Path.Combine(Application.persistentDataPath, "hyperpaddle-scores.txt");
		ReadData();
	}

	void ReadData () {
		try {
			Stream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			StreamReader fileReader = new StreamReader(file);
			fileReader.Close();
		} catch(IOException e) {
			Debug.LogError(e);
		}
	}

	void WriteData (string data) {
		if (string.IsNullOrEmpty(data))
			data = "No scores available.";

		try {
			Stream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			StreamWriter fileWriter = new StreamWriter(file);
			fileWriter.Write(data);
			fileWriter.Close();
		} catch(IOException e) {
			Debug.LogError(e);
		}
	}

	void OnApplicationPause () {
		WriteData("");
	}

	void OnApplicationDestroy () {
		WriteData("");
	}
}
