using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System;

public class LocalScoreboard : MonoBehaviour {

	[Serializable]
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
		filePath = Path.Combine(Application.persistentDataPath, "hyperpaddle-scores.txt");
		ReadData();
	}

	void ReadData () {
		IFormatter binaryFormatter = new BinaryFormatter();

		try {
			Stream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			scoreData = binaryFormatter.Deserialize(file) as ScoreboardData;
			file.Close();
		} catch(IOException e) {
			Debug.LogException(e);
		}
	}

	void WriteData () {
		IFormatter binaryFormatter = new BinaryFormatter();

		try {
			Stream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			binaryFormatter.Serialize(file, scoreData);
			file.Close();
		} catch(IOException e) {
			Debug.LogException(e);
		}
	}

	void OnApplicationPause () {
		WriteData();
	}

	void OnDestroy () {
		WriteData();
	}
}
