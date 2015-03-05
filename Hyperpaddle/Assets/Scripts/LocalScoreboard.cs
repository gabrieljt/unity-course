using UnityEngine;
using System.Collections;
using System.IO;

public class LocalScoreboard : MonoBehaviour {

	void Start () {
		string filePath = Path.Combine(Application.persistentDataPath, "hyperpaddle-scores.txt");
		Debug.Log(filePath);
		Stream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
		StreamWriter fileWriter = new StreamWriter(file);
		fileWriter.Write("Hello World");
		fileWriter.Close();
	}
	
	void Update () {
	
	}
}
