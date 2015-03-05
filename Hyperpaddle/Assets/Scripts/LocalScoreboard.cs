using UnityEngine;
using System.Collections;
using System.IO;

public class LocalScoreboard : MonoBehaviour {

	private string filePath;

	void Awake () {
		filePath = Path.Combine(Application.persistentDataPath, "hyperpaddle-scores.txt");
		ReadData();
	}

	void ReadData () {
		Stream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
		StreamReader fileReader = new StreamReader(file);
		fileReader.Close();
	}

	void WriteData (string data) {
		if (string.IsNullOrEmpty(data))
			data = "No scores available.";

		Stream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
		StreamWriter fileWriter = new StreamWriter(file);
		fileWriter.Write(data);
		fileWriter.Close();
	}

	void OnApplicationPause () {
		WriteData("");
	}

	void OnApplicationDestroy () {
		WriteData("");
	}
}
