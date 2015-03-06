using UnityEngine;
using System.Linq;
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
		var topFive = scoreData.topScores.Reverse().Take(5);

		if (topFive.Any()) return (score > topFive.Last().Key);	
		return true;
	}
	
	public void ClaimCurrentScore (string name) {
		scoreData.topScores.Add(scoreData.currentTopScore, name);
	}
	
	public SortedList<int, string> GetScores () {
		return scoreData.topScores;
	}

	void Awake () {
		filePath = Path.Combine(Application.persistentDataPath, "hyperpaddle-scores.bin");
		ReadData();
	}

	void ReadData () {
		IFormatter binaryFormatter = new BinaryFormatter();

		try {
			Stream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			scoreData = binaryFormatter.Deserialize(file) as ScoreboardData;
			file.Close();
		} catch(IOException e) {
			Debug.Log("Error reading scores file.");
			Debug.LogException(e);
			scoreData = new ScoreboardData();
		} catch(SerializationException e) {
			Debug.Log("Error deserializing scores file.");
			Debug.LogException(e);
			scoreData = new ScoreboardData();
		}
	}

	void WriteData () {
		IFormatter binaryFormatter = new BinaryFormatter();

		try {
			Debug.Log("Writing to file " + filePath);
			Stream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			binaryFormatter.Serialize(file, scoreData);
			file.Close();
		} catch(IOException e) {
			Debug.Log("Error writing scores file.");
			Debug.LogException(e);
		} catch(SerializationException e) {
			Debug.Log("Error serializing scores file.");
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
